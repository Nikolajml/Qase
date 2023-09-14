using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using NLog;

namespace Tests.API
{
    public class CaseApiTest : CommonBaseTest
    {
        private ILogger logger;
        public Case Case { get; set; }
        public Project project { get; set; }

        public List<Case> CasesForDelete = new List<Case>();
        public List<Project> ProjectsForDelete = new List<Project>();

        protected CaseStep _caseStep;
        protected ProjectStep _projectStep;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger = LogManager.GetCurrentClassLogger();

            _caseStep = new CaseStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, _apiClient);

            project = new Project()
            {
                Code = "CASE",
                Title = "MyProjectForCases",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for CaseTests didn't create"); // +++++ Assert inconclusive - что это такое, как использовать?
            }

            ProjectsForDelete.Add(project);                 // +++++ Use OneTimeSetup for Project -  сделал, вынес createProject на уровень OneTimeSetup
        }


        [SetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = project.Code,
                Title = "API Case"
            };
        }


        [Test]
        [Description("Successful API test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateCaseTest()
        {
            var createdCase = _caseStep.CreateTestCase_API(Case);
            logger.Info("Created Case: " + createdCase.ToString());

            if (createdCase.Status == false)
            {
                Assert.Inconclusive("Case didn't create: " + createdCase.ToString());
            }
                        
            Case.Id = createdCase.Result.id.ToString();
            CasesForDelete.Add(Case);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdCase.Status, "Status code: Case didn't create");
                Assert.IsTrue(createdCase.Result.id != 0, "Case Id not present"); // +++++  проверить, что Id существует
            });                        
        }


        [Test]
        [Description("Successful API test to get a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]

        public void GetCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCase_API(Case);
            logger.Info("Created Case: " + createdTestCase.ToString());

            if (createdTestCase.Status == false)
            {
                Assert.Inconclusive("Case didn't create: " + createdTestCase.ToString());
            }

            Case.Id = createdTestCase.Result.id.ToString();
            CasesForDelete.Add(Case);

            var getedTestCase = _caseStep.GetTestCase_API(Case);
            logger.Info("Received Case: " + getedTestCase.Result.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedTestCase.Status, "Status code: Case didn't get");
                Assert.IsTrue(getedTestCase.Result.id != 0, "Case Id not present");
            });
        }


        [Test]
        [Description("Successful API test to update a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCase_API(Case);
            logger.Info("Created Case: " + createdTestCase.ToString());

            if (createdTestCase.Status == false)
            {
                Assert.Inconclusive("Case didn't create: " + createdTestCase.ToString());
            }

            Case.Id = createdTestCase.Result.id.ToString();
            CasesForDelete.Add(Case);

            Case.Title = "Update API";
            Case.Description = "Description API";

            var updatedCase = _caseStep.UpdateTestCase_API(Case);
            logger.Info("Updated Case: " + updatedCase.Result.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedCase.Status, "Status code: Case didn't update");
                Assert.IsTrue(updatedCase.Result.id != 0, "Case Id not present");
            });
        }


        [Test]
        [Description("Successful test to delete a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCase_API(Case);
            logger.Info("Created Case: " + createdTestCase.ToString());

            if (createdTestCase.Status == false)
            {
                Assert.Inconclusive("Case didn't create: " + createdTestCase.ToString());
            }

            Case.Id = createdTestCase.Result.id.ToString();

            var caseResponse = _caseStep.DeleteTestCase_API(Case);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(caseResponse.Status, "Status code: Case didn't delete");
                Assert.IsTrue(caseResponse.Result.id != 0, "Case Id not present");
            });
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var caseForDelete in CasesForDelete)
            {
                _caseStep.DeleteTestCase_API(caseForDelete);
            }

            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject_API(projectForDelete);
            }
        }
    }
}
