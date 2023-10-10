using Bogus;
using Core.Client;
using Core.Core;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Tests.StatusTests
{
    public class CaseCreateTest : CommonBaseTest
    {
        public string? BaseUrl;

        Case Case;

        protected ILogger logger;
        protected IWebDriver Driver;
        protected ApiClient _apiClient;

        public ProjectTPStepsPage ProjectTPStepsPage;
        public CaseStep _caseStep;
        public NavigationSteps NavigationSteps;

        public Faker Faker = new Faker();

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            BaseUrl = config.AppSettings.URL;
            Driver = new Browser().Driver;

            _apiClient = new ApiClient(config.Bearer!);
            logger = LogManager.GetLogger("CreateCaseTest");

            _caseStep = new CaseStep(logger, Driver, _apiClient);
            ProjectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin!);

            if (NavigationSteps.IsPageOpened() == false)
            {
                Assert.Inconclusive("The Projects Page didn't open");
            }
        }


        [Test]
        [Description("Unsuccessful UI Create Case test with empty title")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("WRONG")]
        public void CreateCaseTest()
        {
            Case = new CaseBuilder()
                .SetCaseTitle("")
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();
            Assert.IsTrue(_caseStep.IsPageOpened(), "The CasePage wasn't opened");

            _caseStep.CreateCase(Case);
            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "Title created Case desn't much to expected Case Title");
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, "TP");


            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
