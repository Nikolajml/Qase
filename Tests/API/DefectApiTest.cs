using BusinessObject.Models;
using Core.Utilities;
using NLog;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    public class DefectApiTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string Id { get; set; }

        [Test, Order(1)]
        [Description("Successful API test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void CreateDefectTest()
        {
            var defectRequest = new Defect();
            defectRequest.Code = "OE";
            defectRequest.DefectTitle = "New Defect API";
            defectRequest.ActualResult = "Some result";
            defectRequest.Severity = 2;

            var defectResponse = _defectService.CreateDefect(defectRequest);

            Console.WriteLine($"Case Status: {defectResponse.status}");
            Console.WriteLine($"Case Id: {defectResponse.result.id}");

            Id = defectResponse.result.id.ToString();

            EntityHandler.DefectsForDelete.Add(defectRequest);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, defectResponse.status);
                Assert.AreEqual(Id, defectResponse.result.id.ToString());
            });
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void GetDefectTest()
        {
            var defectRequest = new Defect();
            defectRequest.Code = "OE";

            var defectResponse = _defectService.GetDefect(defectRequest, Id);
            _logger.Info("Case: " + defectResponse.ToString);

            Console.WriteLine($"Case Status: {defectResponse.status}");
            Console.WriteLine($"Case Id: {defectResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, defectResponse.status);
                Assert.AreEqual(Id, defectResponse.result.id.ToString());
            });
        }

        [Test, Order(3)]
        [Description("Successful API test to update a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void UpdateSuiteTest()
        {
            var defectRequest = new Defect();
            defectRequest.Code = "OE";
            defectRequest.DefectTitle = "Updated Defect";
            defectRequest.ActualResult = "Some updated result";
            defectRequest.Severity = 1;

            var suiteResponse = _defectService.UpdateDefect(defectRequest, Id);

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
            var defectRequest = new Defect();
            defectRequest.Code = "OE";

            var defectResponse = _defectService.DeleteDefect(defectRequest, Id);
            _logger.Info("Case: " + defectResponse.ToString());

            Console.WriteLine($"Case Status: {defectResponse.status}");
            Console.WriteLine($"Case Id: {defectResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, defectResponse.status);
                Assert.AreEqual(Id, defectResponse.result.id.ToString());
            });
        }
    }
}
