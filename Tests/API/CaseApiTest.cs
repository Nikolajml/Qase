using UI.Models;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using BusinessObject.Models;
using Steps.Steps;
using Core.Client;

namespace Tests.API
{
    
    public class CaseApiTest : BaseApiTest
    {
        public Case Case { get; set; }
        public Project project { get; set; }

        public List<Case> CasesForDelete = new List<Case>();
        public List<Project> ProjectsForDelete = new List<Project>();                

        protected CaseStep _caseStep;
        protected ProjectStep _projectStep;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _caseStep = new CaseStep(_logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(_logger, _apiClient);

            project = new Project()
            {
                Code = "MPFC",
                Title = "MyProjectForCases",
                Access = "all"
            };

            _projectStep.CreateTestProject(project);        // Assert inconclusive - что это такое, как использовать?
            ProjectsForDelete.Add(project);                 // +++++ Use OneTimeSetup for Project -  сделал, вынес createProject на уровень OneTimeSetup
        }

        [SetUp]
        public void Setup()
        {            

            Case = new Case()
            {
                Code = project.Code,
                Title = "API Case 123" 
            };
        }

        [Test]
        [Description("Successful API test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCase_API(Case);
            Case.Id = createdTestCase.Result.id.ToString();             // как будет работать, если тест упадет - решить с помощью TUPLE
            CasesForDelete.Add(Case);                                   // Ассерт на ОК, а потом действие на ID

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdTestCase.Status, "Status code: Case didn't delete");
                Assert.AreEqual(Case.Id, createdTestCase.Result.id.ToString(), "Case ID don't match"); // проверить, что Id существует
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
            Case.Id = createdTestCase.Result.id.ToString();
            CasesForDelete.Add(Case);

            var getedTestCase = _caseStep.GetTestCase(Case);
            _logger.Info("Case: " + getedTestCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedTestCase.Status, "Status code: Case didn't get");
                Assert.AreEqual(Case.Id, getedTestCase.Result.id.ToString(), "Case ID don't match");
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
            Case.Id = createdTestCase.Result.id.ToString();
            CasesForDelete.Add(Case);

            Case.Title = "Update API";
            Case.Description = "Description API";

            var updatedCase = _caseStep.UpdateTestCase(Case);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedCase.Status, "Status code: Case didn't update");
                Assert.AreEqual(Case.Id, updatedCase.Result.id.ToString(), "Case ID didn't match");
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
            Case.Id = createdTestCase.Result.id.ToString();
            
            var caseResponse = _caseStep.DeleteTestCase(Case);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(caseResponse.Status, "Status code: Case didn't delete");
                Assert.AreEqual(Case.Id, caseResponse.Result.id.ToString(), "Case ID didn't match");
            });
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var caseForDelete in CasesForDelete)
            {
                _caseStep.DeleteTestCase(caseForDelete);
            }

            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject(projectForDelete);
            }
        }
    }
}
