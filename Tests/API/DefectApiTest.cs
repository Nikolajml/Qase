using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;

namespace Tests.API
{
    public class DefectApiTest : BaseApiTest
    {        
        public Defect defect { get; set; }
        public Project project { get; set; }

        public List<Defect> DefectsForDelete = new List<Defect>();
        public List<Project> ProjectsForDelete = new List<Project>();

        protected DefectStep _defectStep;
        protected ProjectStep _projectStep;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _defectStep = new DefectStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, apiClient: _apiClient);
        }

        [SetUp]
        public void Setup()
        {
            project = new Project()
            {
                Code = "MP",
                Title = "MyProjectAPI",
                Access = "all"
            };

            _projectStep.CreateTestProject(project);  
            ProjectsForDelete.Add(project);

            defect = new Defect()
            {
                Code = project.Code,
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
            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            defect.Id = createdTestDefect.Result.id.ToString();
            DefectsForDelete.Add(defect);

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
            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            defect.Id = createdTestDefect.Result.id.ToString();
            DefectsForDelete.Add(defect);

            var getedDefectCase = _defectStep.GetTestDefect_API(defect);            
                        
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
            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            defect.Id = createdTestDefect.Result.id.ToString();
            DefectsForDelete.Add(defect);

            defect.DefectTitle = "Updated Defect";
            defect.ActualResult = "Some updated result";
            defect.Severity = 1;

            var updatedDefectCase = _defectStep.UpdateTestDefect_API(defect);            

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
            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            defect.Id = createdTestDefect.Result.id.ToString();            

            var defectResponse = _defectStep.DeleteTestDefect_API(defect);                

            Assert.Multiple(() =>
            {
                Assert.IsTrue(defectResponse.Status, "Status code: Defect didn't deleted");
                Assert.AreEqual(defect.Id, defectResponse.Result.id.ToString(), "Defect ID didn't match");
            });              
        }    


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var defectForDelete in DefectsForDelete)
            {
                _defectStep.DeleteTestDefect_API(defectForDelete);
            }

            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject(projectForDelete);
            }
        }


        [Test]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetAllDefectsTest()
        {
            var createdTestDefect = _defectStep.GetAllTestDefect_API("TP");

            
            Assert.IsNotEmpty(createdTestDefect, "Status code: Defect didn't deleted");


            //_defectStep.DeleteTestDefectByName("TP");
            //    Assert.AreEqual(defect.Id, defectResponse.Result.id.ToString(), "Defect ID didn't match");
        }
    }
}
