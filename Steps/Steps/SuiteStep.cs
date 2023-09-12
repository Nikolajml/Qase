﻿using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using NLog;
using OpenQA.Selenium;
using RestSharp;
using UI.Models;
using UI.Pages;

namespace Steps.Steps
{
    public class SuiteStep
    {      
        public SuitePopUpPage SuitePopUpPage; 
        protected ApiClient _apiClient;
        protected ILogger _logger;

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

            _logger = logger;
        }


        public void CreateSuit(Suite suite)
        {
            //SuitePopUpPage.OpenPage();
            //SuitePopUpPage.IsPageOpened();
            SuitePopUpPage.SetSuiteName(suite.Name);
            SuitePopUpPage.SetSuiteDescriptione(suite.Description);
            SuitePopUpPage.SetSuitePreconditionse(suite.Preconditions);
            SuitePopUpPage.ClickToCreateSuiteButton();
        }

        public void EditSuit_UI(Suite suite)
        {
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

        public SuiteApiModel CreateTestSuite(Suite suite)
        {            
              var request = new RestRequest(Endpoints.CREATE_SUITE, Method.Post)
                  .AddUrlSegment("code", suite.Code)
                  .AddBody(suite);

              return _apiClient.Execute<SuiteApiModel>(request);
        }

        public SuiteApiModel GetTestSuite(Suite suite)
        {
            var request = new RestRequest(Endpoints.GET_SUITE)
                .AddUrlSegment("code", suite.Code)
                .AddUrlSegment("id", suite.Id)
                .AddBody(suite);

            return _apiClient.Execute<SuiteApiModel>(request);            
        }

        public SuiteApiModel UpdateTestSuite(Suite suite)
        {
            var request = new RestRequest(Endpoints.UPDATE_SUITE, Method.Patch)
                .AddUrlSegment("code", suite.Code)
                .AddUrlSegment("id", suite.Id)
                .AddBody(suite);

            return _apiClient.Execute<SuiteApiModel>(request);
        }

        public SuiteApiModel DeleteTestSuite(Suite suite)
        {
            var request = new RestRequest(Endpoints.DELETE_SUITE, Method.Delete)
                .AddUrlSegment("code", suite.Code)
                .AddUrlSegment("id", suite.Id)
                .AddBody(suite);

            return _apiClient.Execute<SuiteApiModel>(request);
        }
    }
}
