using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using NLog;

namespace Tests.API
{
    public class DefectApiTest : CommonBaseTest
    {
        private ILogger Logger;
        public Defect defect { get; set; }
        public Project project { get; set; }

        public List<Defect> DefectsForDelete = new List<Defect>();
        public List<Project> ProjectsForDelete = new List<Project>();

        protected DefectStep _defectStep;
        protected ProjectStep _projectStep;
                

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger = LogManager.GetCurrentClassLogger();

            _defectStep = new DefectStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, apiClient: _apiClient);

            project = new Project()
            {
                Code = "MPFC",
                Title = "MyProjectForDefects",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for DefectTests didn't create");
            }

            ProjectsForDelete.Add(project);                
        }


        [SetUp]
        public void Setup()
        {            
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
            logger.Info("Created Defect: " + createdTestDefect.ToString());

            if (createdTestDefect.Status == false)
            {
                Assert.Inconclusive("Defect didn't create: " + createdTestDefect.ToString());
            }

            defect.Id = createdTestDefect.Result.id.ToString();
            DefectsForDelete.Add(defect);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdTestDefect.Status, "Status code: Defect didn't created");                
                Assert.IsTrue(createdTestDefect.Result.id != 0, "Defect Id not present");
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
            logger.Info("Created Defect: " + createdTestDefect.ToString());

            if (createdTestDefect.Status == false)
            {
                Assert.Inconclusive("Defect didn't create: " + createdTestDefect.ToString());
            }

            defect.Id = createdTestDefect.Result.id.ToString();
            DefectsForDelete.Add(defect);

            var getedDefect = _defectStep.GetTestDefect_API(defect);
            logger.Info("Geted Defect: " + getedDefect.Result.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedDefect.Status, "Status code: Defect didn't get");
                Assert.AreEqual(defect.Id, getedDefect.Result.id.ToString(), "Defect Is didn't match");
                Assert.AreEqual(defect.DefectTitle, getedDefect.Result.title.ToString(), "Defect Title didn't match");
                Assert.AreEqual(defect.ActualResult, getedDefect.Result.actual_result.ToString(), "Defect Actual Result didn't match");                
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
            logger.Info("Created Defect: " + createdTestDefect.ToString());

            if (createdTestDefect.Status == false)
            {
                Assert.Inconclusive("Defect didn't create: " + createdTestDefect.ToString());
            }

            defect.Id = createdTestDefect.Result.id.ToString();
            DefectsForDelete.Add(defect);

            defect.DefectTitle = "Updated Defect";
            defect.ActualResult = "Some updated result";
            defect.Severity = 1;

            var updatedDefect = _defectStep.UpdateTestDefect_API(defect);
            logger.Info("Updated Defect: " + updatedDefect.ToString());

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedDefect.Status, "Status code: Defect didn't update");
                Assert.AreEqual(defect.Id, updatedDefect.Result.id.ToString(), "Defect ID didn't match");
            });
        }                


        [Test]
        [Description("Successful API test to delete a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteDefectTest()
        {
            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            logger.Info("Created Defect: " + createdTestDefect.ToString());

            if (createdTestDefect.Status == false)
            {
                Assert.Inconclusive("Defect didn't create: " + createdTestDefect.ToString());
            }

            defect.Id = createdTestDefect.Result.id.ToString();            

            var defectResponse = _defectStep.DeleteTestDefect_API(defect);                

            Assert.Multiple(() =>
            {
                Assert.IsTrue(defectResponse.Status, "Status code: Defect didn't deleted");
                Assert.IsTrue(defectResponse.Result.id != 0, "Defect Id not present");
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
                _projectStep.DeleteTestProject_API(projectForDelete);
            }
        }

    }
}
