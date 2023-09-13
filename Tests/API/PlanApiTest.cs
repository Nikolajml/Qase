using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using NLog;

namespace Tests.API
{
    public class PlanApiTest : CommonBaseTest
    {
        private ILogger Logger;
        public Plan plan { get; set; }
        public Case Case { get; set; }
        public Project project { get; set; }

        public List<Case> CasesForDelete = new List<Case>();
        public List<Plan> PlansForDelete = new List<Plan>();
        public List<Project> ProjectsForDelete = new List<Project>();

        protected CaseStep _caseStep;
        protected PlanStep _planStep;
        protected ProjectStep _projectStep;

        int CaseId { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger = LogManager.GetCurrentClassLogger();

            _caseStep = new CaseStep(logger, apiClient: _apiClient);
            _planStep = new PlanStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, apiClient: _apiClient);

            project = new Project()
            {
                Code = "PLAN",
                Title = "MyProjectForPlans",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for DefectTests didn't create");
            }

            ProjectsForDelete.Add(project);
        }

        [SetUp]
        public void SetUp()
        {
            Case = new Case()
            {
                Code = project.Code,
                Title = "Case API Test"
            };

            var createdTestCase = _caseStep.CreateTestCase_API(Case);
            logger.Info("Created Case: " + createdTestCase.ToString());

            if (createdTestCase.Status == false)
            {
                Assert.Inconclusive("Case didn't create: " + createdTestCase.ToString());
            }

            Case.Id = createdTestCase.Result.id.ToString();
            int CaseIdForPlan = int.Parse(Case.Id);
            CaseId = CaseIdForPlan;
            Console.WriteLine(CaseIdForPlan);

            CasesForDelete.Add(Case);

            plan = new Plan()
            {
                Code = project.Code,
                Title = "Plan API Test",
                Cases = new List<int> { CaseIdForPlan }
            };

            PlansForDelete.Add(plan);
        }


        [Test]
        [Description("Successful API test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreatePlanTest()
        {
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();
            PlansForDelete.Add(plan);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdTestPlan.Status, "Status code: Plan didn't create");
                Assert.IsTrue(createdTestPlan.Result.id != 0, "Defect Id not present");
            });
        }


        [Test]
        [Description("Successful API test to get a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetPlanTest()
        {
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();
            PlansForDelete.Add(plan);

            var getedPlanCase = _planStep.GetTestPlan(plan);
            logger.Info("Geted Plan: " + getedPlanCase.Result.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedPlanCase.Status, "Status code: Plan didn't get");
                Assert.AreEqual(plan.Id, getedPlanCase.Result.id.ToString());
                Assert.AreEqual(plan.Title, getedPlanCase.Result.title.ToString(), "Plan ID didn't match");
            });
        }


        [Test]
        [Description("Successful API test to update a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdatePlanTest()
        {
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();
            PlansForDelete.Add(plan);

            plan.Title = "Updated Plan Title API";
            plan.Description = "Updated Plan Description API";
            plan.Cases = new List<int> { CaseId };

            var updatedPlan = _planStep.UpdateTestPlan(plan);
            logger.Info("Updated Plan: " + updatedPlan.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedPlan.Status, "Status code: Plan didn't update");
                Assert.AreEqual(plan.Id, updatedPlan.Result.id.ToString(), "Plan Id didn't match");
            });
        }


        [Test]
        [Description("Successful API test to delete a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeletePlanTest()
        {
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();

            var planResponse = _planStep.DeleteTestPlan(plan);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(planResponse.Status, "Status code: Plan didn't delete");
                Assert.IsTrue(planResponse.Result.id != 0, "Plan Id not present");
            });
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var planForDelete in PlansForDelete)
            {
                _planStep.DeleteTestPlan(planForDelete);
            }

            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject(projectForDelete);
            }
        }
    }
}
