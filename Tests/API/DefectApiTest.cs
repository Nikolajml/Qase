using UI.Models;
using Core.Utilities;
using NLog;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    public class DefectApiTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Defect defect { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            defect = new Defect()
            {
                Code = "OE",
                DefectTitle = "New Defect API",
                ActualResult = "Some result",
                Severity = 2
            };
        }

        [Test, Order(1)]
        [Description("Successful API test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateDefectTest()
        {    
            var defectResponse = _defectService.CreateDefect(defect);

            Console.WriteLine($"Case Status: {defectResponse.status}");
            Console.WriteLine($"Case Id: {defectResponse.result.id}");

            defect.Id = defectResponse.result.id.ToString();

            entityHandler.DefectsForDelete.Add(defect);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, defectResponse.status);
                Assert.AreEqual(defect.Id, defectResponse.result.id.ToString());
            });
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetDefectTest()
        {         
            var defectResponse = _defectService.GetDefect(defect);
            _logger.Info("Defect: " + defectResponse.ToString);

            Console.WriteLine($"Defect Status: {defectResponse.status}");
            Console.WriteLine($"Defect Id: {defectResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, defectResponse.status);
                Assert.AreEqual(defect.Id, defectResponse.result.id.ToString());
            });
        }

        [Test, Order(3)]
        [Description("Successful API test to update a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateDefectTest()
        {
            defect.DefectTitle = "Updated Defect";
            defect.ActualResult = "Some updated result";
            defect.Severity = 1;

            var suiteResponse = _defectService.UpdateDefect(defect);

            Console.WriteLine($"Defect Status: {suiteResponse.status}");
            Console.WriteLine($"Defect Id: {suiteResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, suiteResponse.status);
                Assert.AreEqual(defect.Id, suiteResponse.result.id.ToString());
            });
        }

        [Test, Order(4)]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteSuiteTest()
        {
            var defectResponse = _defectService.DeleteDefect(defect);
            _logger.Info("Defect: " + defectResponse.ToString());

            Console.WriteLine($"Defect Status: {defectResponse.status}");
            Console.WriteLine($"Defect Id: {defectResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, defectResponse.status);
                Assert.AreEqual(defect.Id, defectResponse.result.id.ToString());
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            entityHandler.DeleteDefects();
        }
    }
}
