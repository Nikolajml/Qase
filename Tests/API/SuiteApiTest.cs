using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using NLog;
using Core.Client;
using Core.Utilities.Configuration;

namespace Tests.API
{
    public class SuiteApiTest : CommonBaseTest
    {
        protected ApiClient _apiClient;
        private ILogger logger;

        public Suite suite { get; set; }
        public Project project { get; set; }

        protected SuiteStep _suiteStep;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger = LogManager.GetLogger($"Suite_OneTimeSetUp");
            _apiClient = new ApiClient(logger, config.Bearer!);
                        
            _suiteStep = new SuiteStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, _apiClient);

            project = new Project()
            {
                Code = "SUITE",
                Title = "MyProjectForSuites",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for CaseTests didn't create");
            }

            ProjectsForDelete.Add(project);
        }


        [SetUp]
        public void Setup()
        {
            logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.Name}");                       

            suite = new Suite()
            {
                Code = project.Code,
                Name = "Suite API",
                Description = "Some Description"
            };
        }


        [Test]
        [Description("Successful API test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateSuiteTest()
        {
            logger.Debug("CreateSuitTest!");

            var createdSuiteTest = _suiteStep.CreateTestSuite_API(suite);
            logger.Info("Created Suite: " + createdSuiteTest.ToString());

            if (createdSuiteTest.Status == false)
            {
                Assert.Inconclusive("Suite didn't create: " + createdSuiteTest.ToString());
            }

            suite.Id = createdSuiteTest.Result.id.ToString();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdSuiteTest.Status, "Status code: Suite didn't create");
                Assert.IsTrue(createdSuiteTest.Result.id != 0, "Defect Id not present");
            });
        }


        [Test]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetSuiteTest()
        {
            logger.Debug("GetSuitTest!");

            var createdSuiteTest = _suiteStep.CreateTestSuite_API(suite);
            logger.Info("Created Suite: " + createdSuiteTest.ToString());

            if (createdSuiteTest.Status == false)
            {
                Assert.Inconclusive("Suite didn't create: " + createdSuiteTest.ToString());
            }

            suite.Id = createdSuiteTest.Result.id.ToString();

            var getedSuite = _suiteStep.GetTestSuite_API(suite);
            logger.Info("Geted Suite: " + getedSuite.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedSuite.Status, "Status code: Suite didn't get");
                Assert.AreEqual(suite.Id, getedSuite.Result.id.ToString(), "Suite ID didn't match");
            });
        }


        [Test]
        [Description("Successful API test to update a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateSuiteTest()
        {
            logger.Debug("UpdateSuitTest!");

            var createdSuiteTest = _suiteStep.CreateTestSuite_API(suite);
            logger.Info("Created Suite: " + createdSuiteTest.ToString());

            if (createdSuiteTest.Status == false)
            {
                Assert.Inconclusive("Suite didn't create: " + createdSuiteTest.ToString());
            }

            suite.Id = createdSuiteTest.Result.id.ToString();

            suite.Name = "Updated Suite Name API";
            suite.Description = "Updated Description API";

            var updatedSuite = _suiteStep.UpdateTestSuite_API(suite);
            logger.Info("Updated Suite: " + updatedSuite.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedSuite.Status, "Status code: Suite didn't update");
                Assert.IsTrue(createdSuiteTest.Result.id != 0, "Defect Id not present");
            });
        }


        [Test]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteSuiteTest()
        {
            logger.Debug("DeleteSuitTest!");

            var createdSuiteTest = _suiteStep.CreateTestSuite_API(suite);
            logger.Info("Created Suite: " + createdSuiteTest.ToString());

            if (createdSuiteTest.Status == false)
            {
                Assert.Inconclusive("Suite didn't create: " + createdSuiteTest.ToString());
            }

            suite.Id = createdSuiteTest.Result.id.ToString();

            var suiteResponse = _suiteStep.DeleteTestSuite_API(suite);
            logger.Info("Suite Id: " + suiteResponse.Result.id.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(suiteResponse.Status, "Status code: Suite didn't delete");
                Assert.IsTrue(createdSuiteTest.Result.id != 0, "Defect Id not present");
            });
        }
    }
}
