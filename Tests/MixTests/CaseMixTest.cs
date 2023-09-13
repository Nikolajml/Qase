using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using Tests.UI;
using Core.Core;
using NLog;

namespace Tests.MixTests
{
    public class CaseMixTest : CommonBaseTest
    {
        Case Case { get; set; }
        Project project { get; set; }

        public List<Case> CasesForDelete = new List<Case>();
        public List<Project> ProjectsForDelete = new List<Project>();

        public ProjectStep _projectStep;
        public CaseStep _caseStep;
        public ProjectTPStepsPage _projectTPStepsPage;

        [OneTimeSetUp]
        public void OneTimeTtestSetUp()
        {
            _projectStep = new ProjectStep(logger, _apiClient);
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);                     
        }

        [SetUp]
        public void SetUp()
        {
            project = new Project()
            {
                Code = "MIX",
                Title = "MixCasesTest",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for CaseMixTests didn't create");
            }

            ProjectsForDelete.Add(project);


            Case = new CaseBuilder()
               .SetCaseTitle("MIX TEST CASE Test")
               .SetCode(project.Code)
               .Build();

            var createdTestCase = _caseStep.CreateTestCase_API(Case);

            Case.Id = createdTestCase.Result.id.ToString();
            logger.Info("Created Case Id: " + createdTestCase.Result.id.ToString());
                        
            CasesForDelete.Add(Case);


            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            Assert.IsTrue(NavigationSteps.IsPageOpened());
        }


        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseMixTest()
        {
            Case.Title = "Edited Case UI";
                        
            NavigationSteps.NavigateToProjectForEditCase_MIX();
            _projectTPStepsPage.NavigateToEditCase_MIX();
            _caseStep.EditCase(Case);

            Assert.That(_projectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "Edited Case Title didn't match");
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var testCace in CasesForDelete)
            {
                _caseStep.DeleteTestCase(testCace);
            }

            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject(projectForDelete);
            }
        }
    }
}
