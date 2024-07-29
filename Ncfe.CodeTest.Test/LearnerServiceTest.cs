using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ncfe.CodeTest;

namespace Ncfe.CodeTest.Test
{
    [TestClass]
    public class LearnerServiceTest
    {
        private Mock<IArchivedDataService> _archivedDataService;
        private Mock<IFailoverRepository> _failoverRepository;
        private Mock<ILearnerDataAccess> _learnerDataAccess;
        private LearnerService _learnerService;

        [TestInitialize]
        public void Setup()
        {
            _archivedDataService = new Mock<IArchivedDataService>();
            _failoverRepository = new Mock<IFailoverRepository>();
            _learnerDataAccess = new Mock<ILearnerDataAccess>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            //set up mock repo and send ID

            //act

            //assert
        }
    }
}
