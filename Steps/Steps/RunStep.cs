using API.Services;
using Core.Client;
using OpenQA.Selenium;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;
using UI.Pages.TestRuns;
using UI.Models;
using UI.Pages.TestRunsPages;

namespace Steps.Steps
{
    public class RunStep
    {
        protected ApiClient _apiClient;
        protected ILogger _logger;

        public TestRunsPage TestRunsPage;
        public StartNewTestRunPopUpPage StartNewTestRunPopUpPage;
        public SelectTestCasesPopUpPage SelectTestCasesPopUpPage;  
        public CreatedTestRunPage CreatedTestRunPage;

        public RunStep(ILogger logger, IWebDriver driver = null, ApiClient apiClient = null)
        {
            if (driver != null)
            {
                TestRunsPage = new TestRunsPage(logger, driver);
            }

            if (driver != null)
            {
                StartNewTestRunPopUpPage = new StartNewTestRunPopUpPage(logger, driver);
            }

            if (driver != null)
            {
                SelectTestCasesPopUpPage = new SelectTestCasesPopUpPage(logger, driver);
            }

            if (driver != null)
            {
                CreatedTestRunPage = new CreatedTestRunPage(logger, driver);
            }

            if (apiClient != null)
            {
                _apiClient = apiClient;
            }                        

            _logger = logger;
        }

        // Methods for UI tests
        public bool IsPageOpened()
        {
            return TestRunsPage.IsPageOpened();
        }

        public void NavigateToPlanPage()
        {
            TestRunsPage.OpenPage();
        }

        public void CreateTestRun(Run run)
        {
            _logger.Info($"Create test run new info: {run.ToString()}");

            TestRunsPage.ClickOnCreateTestRunButton();
            StartNewTestRunPopUpPage.ClickOnDescriptionField();
            StartNewTestRunPopUpPage.SetTestRunDescription(run.Description);
            StartNewTestRunPopUpPage.ClickOnSelectCaseButton();
            SelectTestCasesPopUpPage.ClickOnSelectCaseIndicator();
            SelectTestCasesPopUpPage.ClickOnDoneButton();
            StartNewTestRunPopUpPage.ClickOnStartRunButton();
        }

        public string GetRunDescriptionForAssert()
        {
            return CreatedTestRunPage.GetTestRunDescription();
        }


    }
}
