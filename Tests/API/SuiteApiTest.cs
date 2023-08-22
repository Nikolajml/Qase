using UI.Models;
using NLog;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    public class SuiteApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Suite suite { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            suite = new Suite()
            {
                Code = "OE",
                Name = "Suite_api_New"
            };
        }

        [Test, Order(1)]
        [Description("Successful API test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateSuiteTest()
        {            
            var suiteResponse = _suiteService.CreateSuite(suite);

            suite.Id = suiteResponse.result.id.ToString();

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            entityHandler.SuitesForDelete.Add(suite);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(suite.Id, suiteResponse.result.id.ToString());
            });
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetSuiteTest()
        {         
            var suiteResponse = _suiteService.GetSuite(suite);
            _logger.Info("Case: " + suiteResponse.ToString());

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(suite.Id, suiteResponse.result.id.ToString());
            });
        }
        
        [Test, Order(3)]
        [Description("Successful API test to update a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateSuiteTest()
        {            
            suite.Name = "Updated Suite Name API";
            suite.Description = "Updated Description API";

            var suiteResponse = _suiteService.UpdateSuite(suite);

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(suite.Id, suiteResponse.result.id.ToString());
            });
        }

        [Test, Order(4)]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteSuiteTest()
        {   
             var suiteResponse = _suiteService.DeleteSuite(suite);
            _logger.Info("Case: " + suiteResponse.ToString);

            Console.WriteLine($"Case Status: {suiteResponse.status}");
            Console.WriteLine($"Case Id: {suiteResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(suite.Id, suiteResponse.result.id.ToString());
            });                        
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            entityHandler.DeletePlans();
        }
    }
}
