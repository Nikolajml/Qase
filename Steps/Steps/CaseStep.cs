using API.ResponseAPIModels;
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

            _logger = logger;
        }

        public bool IsPageOpened() // ++++++ Название Check нехорошо - уже переделал 
        {
            return CasePage.IsPageOpened(); // ++++++ ассерт должен быть только на уровне тестов - вынес на уровень тестов 
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
                       
        // Methods for API tests
        public CaseApiModel CreateTestCase_API(Case Case)   // TUPLE - почитать, что это такое? Нужно вернуть респонс (статус код) - это одна часть TUPLE, вторая часть TUPLE - модель.
        {                                                   // Подход с TUPLES перенестся на страницу с сервисами. Тройной TUPLE - код контент error
                                                            // Понятно прописать методы - API - UI
                                                        
            var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post) // Использовать как для позитивных, так и для негативных тестов - сделал ++++++
                .AddUrlSegment("code", Case.Code)
                .AddBody(Case);                         // сделать логер частью Page and Service

            return _apiClient.Execute<CaseApiModel>(request);


            //var response = _apiClient.Execute(request); // здесь будет метод из сервисов сервис

            //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); // Ассерты должны быть только в тестах
            //Assert.IsNotEmpty(response.Content);

            //return JsonSerializer.Deserialize<CaseApiModel>(response.Content);
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
            var listOfCases = GetAllTestCase_API(code);

            var testCases = listOfCases.Where(testCase => testCase.title.Equals(name));

            foreach (var testCase in testCases)
            {
                var testCaseForDelte = new Case
                {
                    Id = testCase.id.ToString(),
                    Code = code,
                };

                DeleteTestCase(testCaseForDelte);
            }
        }

        public List<CaseResult> GetAllTestCase_API(string code, int limit = 90)
        {
            var request = new RestRequest(Endpoints.GET_ALL_CASE)
                 .AddUrlSegment("code", code)
                 .AddParameter("limit", limit);

            var response = _apiClient.Execute<GetAllTestCase>(request);

            _logger.Info("Case: " + response.ToString());

            return response.Result.entities;
        }




        //public CaseApiModel CreateTestCaseWithIncorrectRequiredData(Case Case)
        //{
        //    var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post)
        //        .AddUrlSegment("code", Case.Code)
        //        .AddBody(Case);

        //    return _apiClient.Execute<CaseApiModel>(request);            
        //}

        //public CaseApiModel CreateTestCaseWithIncorrectAuthenticated(Case Case)
        //{
        //    var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post)
        //        .AddUrlSegment("code", Case.Code)
        //        .AddBody(Case);

        //    return _apiClient.Execute<CaseApiModel>(request);            
        //}
    }
}
