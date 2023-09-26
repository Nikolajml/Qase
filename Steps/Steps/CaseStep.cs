using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using Core.Utilities;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using System.Net;
using System.Text.Json;
using UI.Models;
using UI.Pages;

namespace Steps.Steps
{
    public class CaseStep
    {
        public CasePage CasePage;
        public CaseService CaseService;
        protected ApiClient _apiClient;
        protected ILogger _logger;

        public CaseStep(ILogger logger, IWebDriver driver = null, ApiClient apiClient = null)
        {
            if (driver != null)
            {
                CasePage = new CasePage(logger, driver);
            }

            if (apiClient != null)
            {
                _apiClient = apiClient;
            }

            if (apiClient != null)
            {
                CaseService = new CaseService(logger, apiClient);
            }

            _logger = logger;
        }

        public bool IsPageOpened() 
        {
            return CasePage.IsPageOpened(); 
        }

        public void CreateCase(Case Case)
        {
            _logger.Info($"Create test case new info: {Case}");

            CasePage.SetCaseName(Case.Title);
            CasePage.ClickToSaveCaseButton();
        }

        public void EditCase(Case Case)
        {
            _logger.Info($"Edit test case new info: {Case}");

            CasePage.ClickToCaseTitleField();
            CasePage.ClearCaseTitleField();
            CasePage.SetEditedCaseName(Case.Title);
            CasePage.ClickToSaveCaseButton();
        }
                       
        // Methods for API tests
        public CaseApiModel CreateTestCase_API(Case Case) 
        {                                               
            var response = CaseService.CreateCase_API(Case);                     

            return response;
        }               

        public CaseApiModel GetTestCase_API(Case Case)
        {
            var response = CaseService.GetCase_API(Case);

            return response;
        }

        public CaseApiModel UpdateTestCase_API(Case testCase)
        {
            var response = CaseService.UpdateCase_API(testCase);

            return response;
        }

        public CaseApiModel DeleteTestCase_API(Case Case)
        {
            var response = CaseService.DeleteCase_API(Case);
                        
            return response;
        }                

        public void DeleteTestCaseByName(string name, string code)
        {
            var listOfCases = GetAllTestCase_API(code);

            var testCases = listOfCases.Where(testCase => testCase.title.Equals(name));

            foreach (var testCase in testCases)
            {
                var testCaseForDelte = new Case
                {
                    Id = testCase.id.ToString(),
                    Code = code,
                };

                DeleteTestCase_API(testCaseForDelte);
            }
        }

        public List<CaseResult> GetAllTestCase_API(string code)
        {            
            var response = CaseService.GetAllCase_API(code);

            _logger.Info("Case: " + response.ToString());

            return response.Result.entities;
        }
    }
}
