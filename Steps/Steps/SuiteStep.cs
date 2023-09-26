using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using Core.Utilities;
using NLog;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using RestSharp;
using UI.Models;
using UI.Pages;
using ILogger = NLog.ILogger;

namespace Steps.Steps
{
    public class SuiteStep
    {
        protected ApiClient _apiClient;
        protected ILogger _logger;
        public SuitePopUpPage SuitePopUpPage;
        public SuiteService SuiteService;         

        public SuiteStep(ILogger logger, IWebDriver driver = null, ApiClient apiClient = null)
        {
            if (driver != null)
            {
                SuitePopUpPage = new SuitePopUpPage(logger, driver);
            }

            if (apiClient != null)
            {
                _apiClient = apiClient;
            }

            if (apiClient != null)
            {
                SuiteService = new SuiteService(logger, apiClient);
            }

            _logger = logger;
        }


        public void CreateSuit(Suite suite)
        {
            _logger.Info($"Create test suite new info: {suite}");

            //SuitePopUpPage.OpenPage();
            //SuitePopUpPage.IsPageOpened();
            SuitePopUpPage.SetSuiteName(suite.Name);
            SuitePopUpPage.SetSuiteDescriptione(suite.Description);
            SuitePopUpPage.SetSuitePreconditionse(suite.Preconditions);
            SuitePopUpPage.ClickToCreateSuiteButton();
        }

        public void EditSuit_UI(Suite suite)
        {
            _logger.Info($"Edit test suite new info: {suite}");

            SuitePopUpPage.ClickToEditSuiteIcon();
            SuitePopUpPage.ClickToClearNameField();
            SuitePopUpPage.ClearNameField();
            SuitePopUpPage.EditSuiteName(suite.Name);
            SuitePopUpPage.ClickToSaveEditButton();
        }

        public void DeleteSuite_UI()
        {
            SuitePopUpPage.DeleteSuite();
        }


        //Methods for API tests        

        public SuiteApiModel CreateTestSuite_API(Suite suite)
        {            
              var response = SuiteService.CreateSuite_API(suite);

              return response;
        }
              

        public SuiteApiModel GetTestSuite_API(Suite suite)
        {
            var response = SuiteService.GetSuite_API(suite);

            return response;            
        }

        public SuiteApiModel UpdateTestSuite_API(Suite suite)
        {
            var response = SuiteService.UpdateSuite_API(suite);

            return response;
        }

        public SuiteApiModel DeleteTestSuite_API(Suite suite)
        {
            var response = SuiteService.DeleteSuite_API(suite);

            return response;
        }
    }
}
