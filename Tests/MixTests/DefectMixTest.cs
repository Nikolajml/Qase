using Core.Core;
using NLog;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.UI;
using UI.Models;

namespace Tests.MixTests
{
    public class DefectMixTest : CommonBaseTest
    {
        protected ILogger logger;
        Defect defect { get; set; }
        Project project { get; set; }

        public List<Defect> DefectsForDelete = new List<Defect>();
        public List<Project> ProjectsForDelete = new List<Project>();

        public DefectStep _defectStep;
        public ProjectStep _projectStep;
        public ProjectTPStepsPage _projectTPStepsPage;
        public NavigationSteps NavigationSteps;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger = LogManager.GetCurrentClassLogger();

            _defectStep = new DefectStep(logger, Driver, _apiClient);
            _projectStep = new ProjectStep(logger, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            project = new Project()
            {
                Code = "MIX",
                Title = "MixDefectTest",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for CaseMixTests didn't create");
            }

            ProjectsForDelete.Add(project);


            defect = new DefectBuilder()
               .SetDefectTitle("Mix Defect UI test")
               .SetActualResult("Some reuslt for defrect")
               .SetCode(project.Code)
               .Build();

            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);

            defect.Id = createdTestDefect.Result.id.ToString();

           // Console.WriteLine(defect.Id);

            //DefectsForDelete.Add(defect);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            Assert.IsTrue(NavigationSteps.IsPageOpened());
        }

        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditDefectMixTest()
        {
            defect.DefectTitle = "Edited Mix Defect UI test";
            defect.ActualResult = "New Updated Result";            
            
            NavigationSteps.NavigateToProjectForEditCase_MIX();
            _projectTPStepsPage.NavigateToDefectsPage();
            _defectStep.EditDefect_UI(defect);
            Assert.That(_defectStep.DefectTitleForFirstAssert_UI, Is.EqualTo(defect.DefectTitle), "Edited Defect Title didn't match");

            _defectStep.NavigateToCreatedDefectForSecondAssert_UI();
            Assert.That(_defectStep.DefectDescriptionForSecondAssert_UI(), Is.EqualTo(defect.ActualResult), "Edited Defect Description didn't match");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject_API(projectForDelete);
            }
        }
    }
}
