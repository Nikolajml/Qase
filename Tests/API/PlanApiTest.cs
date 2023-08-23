using UI.Models;
using NLog;
using NUnit.Allure.Attributes;
using API.Services;
using NUnit.Framework.Internal;

namespace Tests.API
{
    public class PlanApiTest : BaseApiTest
    {       
        public Plan plan { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            plan = new Plan()
            {
                Code = "OE",
                Title = "New Defect API",
                Cases = new List<int> { 50 }
            };
        }


        [Test, Order(1)]
        [Description("Successful API test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreatePlanTest()
        {    
            var createdPlanTest = _planStep.CreateTestPlan(plan);

            plan.Id = createdPlanTest.Result.id.ToString();                        

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdPlanTest.Status);
                Assert.AreEqual(plan.Id, createdPlanTest.Result.id.ToString());
            });
        }               


        [Test, Order(2)]
        [Description("Successful API test to get a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetPlanTest()
        {
            var getedPlanCase = _planStep.GetTestPlan(plan);
            _logger.Info("Plan: " + getedPlanCase.ToString());                        

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedPlanCase.Status);
                Assert.AreEqual(plan.Id, getedPlanCase.Result.id.ToString());
                Assert.AreEqual(plan.Title, getedPlanCase.Result.title.ToString());                
            });
        }
                

        [Test, Order(3)]
        [Description("Successful API test to update a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdatePlanTest()
        {            
            plan.Title = "Updated Plan Title API";
            plan.Description = "Updated Plan Description API";
            plan.Cases = new List<int> { 50 };

            var updatedPlanCase = _planStep.UpdateTestPlan(plan);                        

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedPlanCase.Status);
                Assert.AreEqual(plan.Id, updatedPlanCase.Result.id.ToString());
            });
        }              


        [Test, Order(4)]
        [Description("Successful API test to delete a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeletePlanTest()
        {
            var planResponse = _planStep.DeleteTestPlan(plan);
            _logger.Info("Plan: " + planResponse.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(planResponse.Status);
                Assert.AreEqual(plan.Id, planResponse.Result.id.ToString());
            });
        }
                

        [OneTimeTearDown]
        public void TearDown()
        {
            cleanUpHandler.DeletePlans();
        }
    }
}
