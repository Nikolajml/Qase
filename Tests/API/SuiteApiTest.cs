using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;

namespace Tests.API
{
    public class SuiteApiTest : BaseApiTest
    {
        public Suite suite { get; set; }
        public Project project { get; set; }

        public List<Suite> SuitesForDelete = new List<Suite>();
        public List<Project> ProjectsForDelete = new List<Project>();

        protected SuiteStep _suiteStep;
        protected ProjectStep _projectStep;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _suiteStep = new SuiteStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, _apiClient);
        }

        [SetUp]
        public void Setup()
        {
            _suiteStep = new SuiteStep(logger, apiClient: _apiClient);

            project = new Project()
            {
                Code = "MPFS",
                Title = "MyProjectForSuites",
                Access = "all"
            };

            _projectStep.CreateTestProject(project);
            ProjectsForDelete.Add(project);

            suite = new Suite()
            {
                Code = project.Code,
                Name = "Suite_api_New"
            };
        }


        [Test]
        [Description("Successful API test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateSuiteTest()
        {
            var createdSuiteTest = _suiteStep.CreateTestSuite(suite);
            suite.Id = createdSuiteTest.Result.id.ToString();
            SuitesForDelete.Add(suite);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdSuiteTest.Status, "Status code: Suite didn't create");
                Assert.AreEqual(suite.Id, createdSuiteTest.Result.id.ToString(), "Suite ID didn't match");
            });
        }


        [Test]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetSuiteTest()
        {
            var createdSuiteTest = _suiteStep.CreateTestSuite(suite);
            suite.Id = createdSuiteTest.Result.id.ToString();
            SuitesForDelete.Add(suite);

            var getedSuiteCase = _suiteStep.GetTestSuite(suite);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedSuiteCase.Status, "Status code: Suite didn't get");
                Assert.AreEqual(suite.Id, getedSuiteCase.Result.id.ToString(), "Suite ID didn't match");
            });
        }


        [Test]
        [Description("Successful API test to update a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateSuiteTest()
        {
            var createdSuiteTest = _suiteStep.CreateTestSuite(suite);
            suite.Id = createdSuiteTest.Result.id.ToString();
            SuitesForDelete.Add(suite);

            suite.Name = "Updated Suite Name API";
            suite.Description = "Updated Description API";

            var updatedSuiteCase = _suiteStep.UpdateTestSuite(suite);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedSuiteCase.Status, "Status code: Suite didn't update");
                Assert.AreEqual(suite.Id, updatedSuiteCase.Result.id.ToString(), "Suite ID didn't match");
            });
        }


        [Test]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteSuiteTest()
        {
            var createdSuiteTest = _suiteStep.CreateTestSuite(suite);
            suite.Id = createdSuiteTest.Result.id.ToString();

            var suiteResponse = _suiteStep.DeleteTestSuite(suite);
            logger.Info("Suite Id: " + suiteResponse.Result.id.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(suiteResponse.Status, "Status code: Suite didn't delete");
                Assert.AreEqual(suite.Id, suiteResponse.Result.id.ToString(), "Suite ID didn't match");
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var suiteForDelete in SuitesForDelete)
            {
                _suiteStep.DeleteTestSuite(suiteForDelete);
            }

            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject(projectForDelete);
            }
        }
    }
}
