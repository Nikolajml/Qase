using UI.Models;
using Core.Utilities;
using NLog;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    public class DefectApiTest : BaseApiTest
    {        
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
            var createdDefectCase = _defectStep.CreateTestDefect(defect);            

            defect.Id = createdDefectCase.Result.id.ToString();

            cleanUpHandler.DefectsForDelete.Add(defect);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdDefectCase.Status);
                Assert.AreEqual(defect.Id, createdDefectCase.Result.id.ToString());
            });
        }

        
        [Test, Order(2)]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetDefectTest()
        {         
            var getedDefectCase = _defectStep.GetTestDefect(defect);
            _logger.Info("Defect: " + getedDefectCase.ToString);
                        
            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedDefectCase.Status);
                Assert.AreEqual(defect.Id, getedDefectCase.Result.id.ToString());
                Assert.AreEqual(defect.DefectTitle, getedDefectCase.Result.title.ToString());
                Assert.AreEqual(defect.ActualResult, getedDefectCase.Result.actual_result.ToString());                
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

            var updatedDefectCase = _defectStep.UpdateTestDefect(defect);
                        
            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedDefectCase.Status);
                Assert.AreEqual(defect.Id, updatedDefectCase.Result.id.ToString());
            });
        }                


        [Test, Order(4)]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteSuiteTest()
        {
            var defectResponse = _defectStep.DeleteTestDefect(defect);
            _logger.Info("Defect: " + defectResponse.ToString());                        

            Assert.Multiple(() =>
            {
                Assert.IsTrue(defectResponse.Status);
                Assert.AreEqual(defect.Id, defectResponse.Result.id.ToString());
            });
        }    


        [OneTimeTearDown]
        public void TearDown()
        {
            cleanUpHandler.DeleteDefects();
        }
    }
}
