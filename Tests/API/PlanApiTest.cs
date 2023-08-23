using UI.Models;
using NLog;
using NUnit.Allure.Attributes;
using API.Services;

namespace Tests.API
{
    public class PlanApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

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
            var planResponse = _planService.CreatePlan(plan);

            plan.Id = planResponse.Result.id.ToString();

            Console.WriteLine($"Plan Status: {planResponse.Status}");
            Console.WriteLine($"Plan Id: {planResponse.Result.id}");

            Assert.AreEqual(true, planResponse.Status);
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetPlanTest()
        {
            var planResponse = _planService.GetPlan(plan);
            _logger.Info("Case: " + planResponse.ToString());

            Console.WriteLine($"Plan Status: {planResponse.Status}");
            Console.WriteLine($"Plan Id: {planResponse.Result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, planResponse.Status);
                Assert.AreEqual(plan.Id, planResponse.Result.id.ToString());
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

            var planResponse = _planService.UpdatePlan(plan);

            Console.WriteLine($"Plan Status: {planResponse.Status}");
            Console.WriteLine($"Plan Id: {planResponse.Result.id}");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(planResponse.Status);
                Assert.AreEqual(plan.Id, planResponse.Result.id.ToString());
            });
        }

        [Test, Order(4)]
        [Description("Successful API test to delete a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeletePlanTest()
        {
            var planResponse = _planService.DeletePlan(plan);
            _logger.Info("Case: " + planResponse.ToString());

            Console.WriteLine($"Plan Status: {planResponse.Status}");
            Console.WriteLine($"Plan Id: {planResponse.Result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, planResponse.Status);
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
