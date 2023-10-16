using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using NLog;
using Core.Client;
using Core.Utilities.Configuration;

namespace Tests.API
{
    public class DefectApiTest : CommonBaseTest
    {
        protected ApiClient _apiClient;
        private ILogger logger;

        public Defect defect { get; set; }
        public Project project { get; set; }
                
        protected DefectStep _defectStep;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger = LogManager.GetLogger($"Defect_OneTimeSetUp");
            _apiClient = new ApiClient(logger, config.Bearer!);
                        
            _defectStep = new DefectStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, _apiClient);

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
            logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.Name}");

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
            logger.Debug("CreateDefectTest!");

            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            logger.Info("Created Defect: " + createdTestDefect.ToString());

            if (createdTestDefect.Status == false)
            {
                Assert.Inconclusive("Defect didn't create: " + createdTestDefect.ToString());
            }

            defect.Id = createdTestDefect.Result.id.ToString();

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
            logger.Debug("GetDefectTest!");

            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            logger.Info("Created Defect: " + createdTestDefect.ToString());

            if (createdTestDefect.Status == false)
            {
                Assert.Inconclusive("Defect didn't create: " + createdTestDefect.ToString());
            }

            defect.Id = createdTestDefect.Result.id.ToString();

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
            logger.Debug("UpdateDefectTest!");

            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);
            logger.Info("Created Defect: " + createdTestDefect.ToString());

            if (createdTestDefect.Status == false)
            {
                Assert.Inconclusive("Defect didn't create: " + createdTestDefect.ToString());
            }

            defect.Id = createdTestDefect.Result.id.ToString();

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
            logger.Debug("DeleteDefectTest!");

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
    }
}
