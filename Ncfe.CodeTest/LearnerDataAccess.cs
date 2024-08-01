using System;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    public class LearnerDataAccess
    {
        public async Task<LearnerResponse> LoadLearner(int learnerId)
        {
            // rettrieve learner from 3rd party webservice
            // simulate network
            Random random = new Random();
            await Task.Delay(500);

            // what is considered low SLA?
            if (random.Next(0, 9) == 0) // 1 in 10 chance to succeed
                throw new Exception("Failed");

            return new LearnerResponse();
        }
    }
}
