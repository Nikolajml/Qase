using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using UI.Models;
using UI.Pages;
using static API.ResponseAPIModels.GetAllTestCase;

namespace Steps.Steps
{
    public class CaseStep
    {
        public CasePage CasePage => new CasePage(Driver); // сделать полем
        protected IWebDriver Driver; // убрать строчку

        public CaseStep(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CheckThatPageIsOpen()
        {            
            Assert.IsTrue(CasePage.IsPageOpened(), "The Case Page wasn't opened");
        }            

        public void CreateCase(Case Case)
        {
            CasePage.SetCaseName(Case.Title);
            CasePage.ClickToSaveCaseButton();
        }

        public void EditCase(Case Case)
        {
            CasePage.ClickToCaseTitleField();
            CasePage.ClearCaseTitleField();
            CasePage.SetEditedCaseName(Case.Title);
            CasePage.ClickToSaveCaseButton();
        }




        protected ApiClient _apiClient;

        protected Logger _logger = LogManager.GetCurrentClassLogger();
        public CaseStep(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public CaseApiModel CreateTestCase(Case Case)
        {
            var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post)
                .AddUrlSegment("code", Case.Code)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel CreateTestCaseWithIncorrectAuthenticated(Case Case)
        {
            var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post)
                .AddUrlSegment("code", Case.Code)
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e88")
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel GetTestCase(Case Case)
        {
            var request = new RestRequest(Endpoints.GET_CASE)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        

        public CaseApiModel UpdateTestCase(Case testCase)
        {
            var request = new RestRequest(Endpoints.UPDATE_CASE, Method.Patch)
                .AddUrlSegment("code", testCase.Code)
                .AddUrlSegment("id", testCase.Id)
                .AddBody(new Case() { Title = testCase.Title, Description = testCase.Description });

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel DeleteTestCase(Case Case)
        {
            var request = new RestRequest(Endpoints.DELETE_CASE, Method.Delete)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }


        public void DeleteTestCaseByName(string name, string code)
        {
            var listOfCases = GetAllTestCase(code);

            var testCases = listOfCases.Where(testCase => testCase.title.Equals(name));

            foreach(var testCase in testCases)
            {
                var testCaseForDelte = new Case
                {
                    Id = testCase.id.ToString(),
                    Code = code,
                };

                DeleteTestCase(testCaseForDelte);
            }          
        }


        public GetAllTestCase GetAllCase(string code)
        {
            var request = new RestRequest(Endpoints.GET_ALL_CASE)
                .AddUrlSegment("code", code)
                .AddParameter("limit", 99);

            return _apiClient.Execute<GetAllTestCase>(request);
        }

        public List<CaseResult> GetAllTestCase(string code)
        {
            var response = GetAllCase(code);

            _logger.Info("Case: " + response.ToString());

            return response.Result.entities;
        }
    }
}
