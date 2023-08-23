using UI.Models;
using NLog;
using NUnit.Allure.Attributes;
using System.Numerics;

namespace Tests.API
{
    public class SuiteApiTest : BaseApiTest
    {       
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
            var createdSuiteTest = _suiteStep.CreateTestSuite(suite);

            suite.Id = createdSuiteTest.Result.id.ToString();

            cleanUpHandler.SuitesForDelete.Add(suite);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdSuiteTest.Status);
                Assert.AreEqual(suite.Id, createdSuiteTest.Result.id.ToString());
            });
        }
                

        [Test, Order(2)]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetSuiteTest()
        {         
            var getedSuiteCase = _suiteStep.GetTestSuite(suite);
            _logger.Info("Suite: " + getedSuiteCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedSuiteCase.Status);
                Assert.AreEqual(suite.Id, getedSuiteCase.Result.id.ToString());
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

            var updatedSuiteCase = _suiteStep.UpdateTestSuite(suite);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedSuiteCase.Status);
                Assert.AreEqual(suite.Id, updatedSuiteCase.Result.id.ToString());
            });
        }
          

        [Test, Order(4)]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteSuiteTest()
        {   
             var suiteResponse = _suiteStep.DeleteTestSuite(suite);
            _logger.Info("Suite: " + suiteResponse.ToString);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(suiteResponse.Status);
                Assert.AreEqual(suite.Id, suiteResponse.Result.id.ToString());
            });                        
        }
                

        [OneTimeTearDown]
        public void TearDown()
        {
            cleanUpHandler.DeletePlans();
        }
    }
}
