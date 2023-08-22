using UI.Models;
using NLog;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    public class CaseApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Case Case { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "OE",
                Title = "Case_api_New"
            };
        }
        
        [Test, Order(1)]
        [Description("Successful API test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateCaseTest()
        {
            var caseResponse = _caseService.CreateCase(Case);

            Case.Id = caseResponse.result.id.ToString();

            Console.WriteLine($"Case Status: {caseResponse.status}");
            Console.WriteLine($"Case Id: {caseResponse.result.id}");

            entityHandler.CasesForDelete.Add(Case);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Case.Id, caseResponse.result.id.ToString());
            });
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]

        public void GetCaseTest()
        {
            var caseResponse = _caseService.GetCase(Case);
            _logger.Info("Case: " + caseResponse.ToString());

            Console.WriteLine($"Case Status: {caseResponse.status}");
            Console.WriteLine($"Case Id: {caseResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Case.Id, caseResponse.result.id.ToString());
            });
        }

        [Test, Order(3)]
        [Description("Successful API test to update a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateCaseTest()
        {
            Case.Title = "New Update API";
            Case.Description = "New Description API";

            var caseResponse = _caseService.UpdateCase(Case);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Case.Id, caseResponse.result.id.ToString());
            });
        }

        [Test, Order(4)]
        [Description("Successful test to delete a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteCaseTest()
        {

            var caseResponse = _caseService.DeleteCase(Case);
            _logger.Info("Case: " + caseResponse.ToString());

            Console.WriteLine($"Case Status: {caseResponse.status}");
            Console.WriteLine($"Case Id: {caseResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Case.Id, caseResponse.result.id.ToString());
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            entityHandler.DeleteCases();
        }
    }
}
