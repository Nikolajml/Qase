using Core.Client;
using NLog;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Tests.StatusTests
{
    public class CaseStatusTest2 : CommonBaseTest
    {
        protected ApiClient _apiClient;
        private ILogger logger;

        public Case Case { get; set; }
        public Project project { get; set; }

        protected CaseStep _caseStep;

        [SetUp]
        public void Setup()
        {            
            logger = LogManager.GetLogger($"CreateCase with wrong Data");
            _apiClient = new ApiClient(logger, config.Bearer!);

            _caseStep = new CaseStep(logger, apiClient: _apiClient);
            _projectStep = new ProjectStep(logger, _apiClient);

            project = new Project()
            {
                Code = "CASE",
                Title = "MyProjectForCases",
                Access = "all" 
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for CaseTests didn't create");
            }

            ProjectsForDelete.Add(project);

            Case = new Case()
            {
                Code = project.Code,
                Title = ""
            };
        }

        [Test]
        [Description("Unsuccessful CreateCaseAPITest with wrong Data")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("WRONG")]
        public void CreateCaseTestWithWrongCaseData()
        {
            //logger.Debug("CreateUnsuccessfulCaseTest!");

            var createdCase = _caseStep.CreateTestCase_API(Case);
            logger.Info("Created Case: " + createdCase.ToString());

            //if (createdCase.Status == false)                        // the test will fail because a required field is missing
            //{
            //    Assert.Inconclusive("Case didn't create: " + createdCase.ToString());
            //}

            Case.Id = createdCase.Result.id.ToString();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdCase.Status, "Status code: Case didn't create");
                Assert.IsTrue(createdCase.Result.id != 0, "Case Id not present");
            });
        }
    }
}
