using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ncfe.CodeTest;
using System.Data.SQLite;
using System.Data.Entity;

namespace Ncfe.CodeTest.Test
{
    [TestClass]
    public class LearnerServiceTest
    {
        private Mock<IArchivedDataService> _archivedDataService;
        private Mock<IFailoverRepository> _failoverRepository;
        private Mock<ILearnerDataAccess> _learnerDataAccess;
        private LearnerService _learnerService;

        private string _connectionString;

        [TestInitialize]
        public void Setup()
        {
            _archivedDataService = new Mock<IArchivedDataService>();
            _failoverRepository = new Mock<IFailoverRepository>();
            _learnerDataAccess = new Mock<ILearnerDataAccess>();

            //todo: put in a config file
            _connectionString = "Data Source=:memory:;Version=3;New=True;";

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var context = new CodeTestDbContext(_connectionString))
                {
                    context.Database.CreateIfNotExists();
                }
            }
        }

        [TestMethod]
        public void Learner_100entries()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var context = new CodeTestDbContext(_connectionString))
                {
                    //arrange
                    //insert 100 entries
                    for (int i = 0; i < 99; i++)
                    {
                        context.Learners.Add(new Learner { Name = "Test Learner "+i, Id = i });
                    }

                    //act
                    context.SaveChanges();

                    //assert
                    Assert.AreEqual(100, context.Learners.Local.Count);
                }
            }
        }
    }
}
