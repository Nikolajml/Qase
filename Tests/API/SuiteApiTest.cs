using BusinessObject.Models;
using NLog;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    public class SuiteApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string Id { get; set; }

        [Test, Order(1)]
        [Description("Successful API test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void CreateSuiteTest()
        {
            var suiteRequest = new Suite();
            suiteRequest.Code = "OE";
            suiteRequest.Name = "Case_api_New";

            var suiteResponse = _suiteService.CreateSuite(suiteRequest);

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            Id = suiteResponse.result.id.ToString();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(Id, suiteResponse.result.id.ToString());
            });
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void GetSuiteTest()
        {
            var suiteRequest = new Suite();
            suiteRequest.Code = "OE";

            var suiteResponse = _suiteService.GetSuite(suiteRequest, Id);
            _logger.Info("Case: " + suiteResponse.ToString);

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(Id, suiteResponse.result.id.ToString());
            });
        }

        [Test, Order(3)]
        [Description("Successful API test to update a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void UpdateSuiteTest()
        {
            var suiteRequest = new Suite();
            suiteRequest.Code = "OE";
            suiteRequest.Name = "Updated Suite Name API";
            suiteRequest.Description = "Updated Description API";

            var suiteResponse = _suiteService.UpdateSuite(suiteRequest, Id);

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(Id, suiteResponse.result.id.ToString());
            });
        }

        [Test, Order(4)]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void DeleteSuiteTest()
        {
            var suiteRequest = new Suite();
            suiteRequest.Code = "OE";

            var suiteResponse = _suiteService.DeleteSuite(suiteRequest, Id);
            _logger.Info("Case: " + suiteResponse.ToString);

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(Id, suiteResponse.result.id.ToString());
            });
        }
    }
}
