using NLog;
using NUnit.Allure.Attributes;
using Steps.Steps;
using UI.Models;

namespace Tests.MixTests
{
    public class PlanMixTest : CommonBaseTest
    {
        protected ILogger logger;
        Plan plan { get; set; }
        Case Case { get; set; }
        Project project { get; set; }
                
        public List<Project> ProjectsForDelete = new List<Project>();

        public ProjectStep _projectStep;
        public CaseStep _caseStep;
        public PlanStep _planStep;
        public NavigationSteps NavigationSteps;
        public ProjectTPStepsPage ProjectTPStepsPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger = LogManager.GetCurrentClassLogger();

            _projectStep = new ProjectStep(logger, _apiClient);
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _planStep = new PlanStep(logger, Driver, _apiClient);
            NavigationSteps = new NavigationSteps(logger, Driver);
            ProjectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            project = new Project()
            {
                Code = "MIX",
                Title = "MixPlanTest",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for PlanMixTests didn't create");
            }

            ProjectsForDelete.Add(project);


            Case = new Case()
            {
                Code = project.Code,
                Title = "Case for Plan Mix Test"
            };

            var createdTestCase = _caseStep.CreateTestCase_API(Case);

            if (createdTestCase.Status == false)
            {
                Assert.Inconclusive("The Case for PlanMixTests didn't create");
            }

            Case.Id = createdTestCase.Result.id.ToString();
            int CaseIdForPlan = int.Parse(Case.Id);
            Console.WriteLine($"Case Id: {CaseIdForPlan}");


            plan = new Plan()
            {
                Code = project.Code,
                Title = "New Defect MIX",
                Cases = new List<int> { CaseIdForPlan }
            };

            var createdTestPlan = _planStep.CreateTestPlan_API(plan);

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("The Plan for PlanMixTests didn't create");
            }

            plan.Id = createdTestPlan.Result.id.ToString();
            Console.WriteLine($"Plan Id: {plan.Id}");

            
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            Assert.IsTrue(NavigationSteps.IsPageOpened());
        }


        [Test]
        [Description("Edit Plan via UI after created and delete plan via API")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditPlanMixTest()
        {
            plan.Title = "Edited Mix Plan Mix Test";
            plan.Description = "Edited Description";

            NavigationSteps.NavigateToProjectForEditCase_MIX();
            ProjectTPStepsPage.NavigateToPlansPage();
            _planStep.EditPlan(plan);

            Assert.That(_planStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title), "Edited plan Title didn't match");                        
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
