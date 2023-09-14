using NLog;
using NUnit.Allure.Attributes;
using Steps.Steps;
using UI.Models;

namespace Tests.MixTests
{
    public class SuiteMixTest : CommonBaseTest
    {
        protected ILogger logger;
        Suite suite { get; set; }
        Project project { get; set; }
                
        public List<Project> ProjectsForDelete = new List<Project>();

        public ProjectStep _projectStep;
        public SuiteStep _suiteStep;
        public ProjectTPStepsPage _projectTPStepsPage;
        public NavigationSteps NavigationSteps;


        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            logger = LogManager.GetCurrentClassLogger();

            _projectStep = new ProjectStep(logger, _apiClient);
            _suiteStep = new SuiteStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);            
        }

        [SetUp]
        public void SetUp()
        {
            project = new Project()
            {
                Code = "MIX",
                Title = "MixPlansTest",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for SuiteMixTests didn't create");
            }

            ProjectsForDelete.Add(project);


            suite = new SuiteBuilder()
               .SetSuiteName("New Mix Case UI test")
               .SetSuiteCode(project.Code)
               .Build();

            var createdTestSuite = _suiteStep.CreateTestSuite_API(suite);
            logger.Info("Created Suite: " + createdTestSuite.ToString());

            if (createdTestSuite.Status == false)
            {
                Assert.Inconclusive("Suite didn't create: " + createdTestSuite.ToString());
            }

            suite.Id = createdTestSuite.Result.id.ToString();
            logger.Info("Created Suite Id: " + createdTestSuite.Result.id.ToString());

            if (createdTestSuite.Status == false)
            {
                Assert.Inconclusive("The Project for SuiteMixTests didn't create");
            }


            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            Assert.IsTrue(NavigationSteps.IsPageOpened());
        }


        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditSuiteMixTest()
        {
            suite.Name = "Edited Mix Suite UI test";

            NavigationSteps.NavigateToProjectForEditCase_MIX();
            _suiteStep.EditSuit_UI(suite);

            Assert.That(_projectTPStepsPage.CreatedSuiteNameForAssert(suite.Name), Is.EqualTo(suite.Name), "Edited Suite Name didn't match");
        }

        [OneTimeTearDown]
        public void TearDown()
        {      
            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject_API(projectForDelete);
            }
        }
    }
}
