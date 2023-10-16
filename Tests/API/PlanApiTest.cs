using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using NLog;
using Core.Client;
using Core.Utilities.Configuration;

namespace Tests.API
{
    public class PlanApiTest : CommonBaseTest
    {
        protected ApiClient _apiClient;
        private ILogger logger;

        public Plan plan { get; set; }
        public Case Case { get; set; }
        public Project project { get; set; }               

        protected CaseStep _caseStep;
        protected PlanStep _planStep;
        protected ProjectStep _projectStep;

        int CaseId { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger = LogManager.GetLogger($"Plan_OneTimeSetUp");
            _apiClient = new ApiClient(logger, config.Bearer!);
                        
            _caseStep = new CaseStep(logger, apiClient: _apiClient);
            _planStep = new PlanStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, apiClient: _apiClient);

            project = new Project()
            {
                Code = "PLAN",
                Title = "MyProjectForPlans",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for DefectTests didn't create");
            }

            ProjectsForDelete.Add(project);
        }

        [SetUp]
        public void SetUp()
        {
            logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.Name}");
                        
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
                        
            plan = new Plan()
            {
                Code = project.Code,
                Title = "Plan API Test",
                Cases = new List<int> { CaseIdForPlan }
            };
        }


        [Test]
        [Description("Successful API test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreatePlanTest()
        {
            logger.Debug("CreatePlanTest!");

            var createdTestPlan = _planStep.CreateTestPlan_API(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();

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
            logger.Debug("GetPlanTest!");

            var createdTestPlan = _planStep.CreateTestPlan_API(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();

            var getedPlanCase = _planStep.GetTestPlan_API(plan);
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
            logger.Debug("UpdatePlanTest!");

            var createdTestPlan = _planStep.CreateTestPlan_API(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();

            plan.Title = "Updated Plan Title API";
            plan.Description = "Updated Plan Description API";
            plan.Cases = new List<int> { CaseId };

            var updatedPlan = _planStep.UpdateTestPlan_API(plan);
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
            logger.Debug("DeletePlanTest!");

            var createdTestPlan = _planStep.CreateTestPlan_API(plan);
            logger.Info("Created Plan: " + createdTestPlan.ToString());

            if (createdTestPlan.Status == false)
            {
                Assert.Inconclusive("Plan didn't create: " + createdTestPlan.ToString());
            }

            plan.Id = createdTestPlan.Result.id.ToString();

            var planResponse = _planStep.DeleteTestPlan_API(plan);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(planResponse.Status, "Status code: Plan didn't delete");
                Assert.IsTrue(planResponse.Result.id != 0, "Plan Id not present");
            });
        }
    }
}
