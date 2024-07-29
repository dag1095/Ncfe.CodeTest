using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    public class LearnerService : ILearnerService
    {
        private IArchivedDataService _archivedDataService;
        private IFailoverRepository _failoverRepository;
        private ILearnerDataAccess _learnerDataAccess;

        LearnerService(IArchivedDataService archivedDataService, IFailoverRepository failoverRepository, ILearnerDataAccess learnerDataAccess)
        {
            _archivedDataService = archivedDataService;
            _failoverRepository = failoverRepository;
            _learnerDataAccess = learnerDataAccess;
        }

        private static string _failoverModeString = "IsFailoverModeEnabled";
        private static bool? GetFailoverMode()
        {
            try
            {
                string failoverMode = ConfigurationManager.AppSettings[_failoverModeString];

                if (string.IsNullOrEmpty(failoverMode))
                {
                    Console.WriteLine("failover mode parameter is null or empty");
                    return null;
                }

                return bool.Parse(failoverMode);
            }
            catch(FormatException fex)
            {
                Console.WriteLine($"failover mode parameter is not a valid boolean value: {fex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"an error occurred while retreiving the parameter '{ex.Message}'");
                return null;
            }
        }

        private static int _maxFailedRequests = 100;
        private static bool? _isFailoverModeEnabled = GetFailoverMode();
        public Learner GetLearner(int learnerId)
        {
            // Check HasValue Here?
            if (!_isFailoverModeEnabled.HasValue)
                return null;

            var failoverEntries = _failoverRepository.GetFailOverEntries();

            LearnerResponse learnerResponse;
            Learner learner;
            
            // check failed entries count and failover mode                 // Or HasValue here?
            if (failoverEntries.Count() > _maxFailedRequests && /*_isFailoverModeEnabled.HasValue &&*/ _isFailoverModeEnabled.Value)
            {
                learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
            }
            else
            {
                learnerResponse = _learnerDataAccess.LoadLearner(learnerId);
            }

            if (learnerResponse.IsArchived)
            {
                learner = _archivedDataService.GetArchivedLearner(learnerId);
            }
            else
            {
                learner = learnerResponse.Learner;
            }

            return learner;
        }

        public Learner GetArchivedLearner(int learnerId)
        {
            var archivedLearner = _archivedDataService.GetArchivedLearner(learnerId);

            return archivedLearner;
        }
    }
}
