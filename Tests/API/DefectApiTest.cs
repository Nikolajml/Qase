using UI.Models;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    public class DefectApiTest : BaseApiTest
    {
        public List<Defect> DefectsForDelete;
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


        [Test]
        [Description("Successful API test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateDefectTest()
        {    
            var createdTestDefect = _defectStep.CreateTestDefect(defect);
            defect.Id = createdTestDefect.Result.id.ToString();
            cleanUpHandler.DefectsForDelete.Add(defect);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdTestDefect.Status, "Status code: Defect didn't created");
                Assert.AreEqual(defect.Id, createdTestDefect.Result.id.ToString());
            });
        }

        
        [Test]
        [Description("Successful API test to get a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetDefectTest()
        {
            var createdTestDefect = _defectStep.CreateTestDefect(defect);
            defect.Id = createdTestDefect.Result.id.ToString();
            cleanUpHandler.DefectsForDelete.Add(defect);

            var getedDefectCase = _defectStep.GetTestDefect(defect);            
                        
            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedDefectCase.Status, "Status code: Defect didn't get");
                Assert.AreEqual(defect.Id, getedDefectCase.Result.id.ToString(), "Defect ID didn't match");
                Assert.AreEqual(defect.DefectTitle, getedDefectCase.Result.title.ToString(), "Defect Title didn't match");
                Assert.AreEqual(defect.ActualResult, getedDefectCase.Result.actual_result.ToString(), "Defect Actual Result didn'tmatch");                
            });
        }        


        [Test]
        [Description("Successful API test to update a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateDefectTest()
        {
            var createdTestDefect = _defectStep.CreateTestDefect(defect);
            defect.Id = createdTestDefect.Result.id.ToString();
            cleanUpHandler.DefectsForDelete.Add(defect);

            defect.DefectTitle = "Updated Defect";
            defect.ActualResult = "Some updated result";
            defect.Severity = 1;

            var updatedDefectCase = _defectStep.UpdateTestDefect(defect);            

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedDefectCase.Status, "Status code: Defect didn't update");
                Assert.AreEqual(defect.Id, updatedDefectCase.Result.id.ToString(), "Defect ID didn't match");
            });
        }                


        [Test]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteSuiteTest()
        {
            var createdTestDefect = _defectStep.CreateTestDefect(defect);
            defect.Id = createdTestDefect.Result.id.ToString();            

            var defectResponse = _defectStep.DeleteTestDefect(defect);                

            Assert.Multiple(() =>
            {
                Assert.IsTrue(defectResponse.Status, "Status code: Defect not be deleted");
                Assert.AreEqual(defect.Id, defectResponse.Result.id.ToString(), "Defect ID don't match");
            });              
        }    


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var defectForDelete in DefectsForDelete)
            {
                _defectStep.DeleteTestDefect(defectForDelete);
            }
        }        
    }
}
