using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using UI.Models;
using UI.Pages;

namespace Steps.Steps
{
    public class DefectStep
    {
        public DefectsTPPage DefectsTPPage;
        protected ApiClient _apiClient;
        protected ILogger _logger;
        public DefectStep(ILogger logger, IWebDriver driver = null, ApiClient apiClient = null)
        {
            if (driver != null)
            {
                DefectsTPPage = new DefectsTPPage(logger, driver);
            }

            if (apiClient != null)
            {
                _apiClient = apiClient;
            }

            _logger = logger;
        }


        public void CheckThatDefectPageIsOpen()
        {
            Assert.IsTrue(DefectsTPPage.IsPageOpened(), "The Defect Page wasn't opened");
        }

        public void CreateDefect_UI(Defect defect)
        {                        
            DefectsTPPage.ClickToCreateNewDefectButton();
            DefectsTPPage.SetDefectTitle(defect.DefectTitle);
            DefectsTPPage.SetActualresult(defect.ActualResult);
            DefectsTPPage.ClickToCreateDefectButton();
        }

        public string DefectTitleForFirstAssert_UI()
        {
            return DefectsTPPage.GetDefectTitle();
        }

        public void NavigateToCreatedDefectForSecondAssert_UI()
        {
            DefectsTPPage.ClickToDefectTitleToSecondAssert();
        }

        public string DefectTitleForSecondAssert_UI()
        {
            return DefectsTPPage.GetDefectTitleForSecondAssert();
        }

        public string DefectDescriptionForSecondAssert_UI()
        {
            return DefectsTPPage.GetDefectDescriptionForSecondAssert();
        }




        public void NavigateToDefectPage_UI()
        {
            DefectsTPPage.OpenPage();
        }

        public void EditDefect_UI(Defect defect)
        {
            DefectsTPPage.ClickToDefectTitle();
            DefectsTPPage.ClickToDefectEdit();
            DefectsTPPage.ClickToClearTitleDefectField();
            DefectsTPPage.ClearTitleDefectField();
            DefectsTPPage.SetEditedDefectTitle(defect.DefectTitle);
            DefectsTPPage.ClickToClearActualResult();
            DefectsTPPage.ClearActualResultField();
            DefectsTPPage.SetEditedActualResult(defect.ActualResult);
            DefectsTPPage.ClickToUpdateDefectButton();
        }


        public void DeleteDefect_UI()
        {
            DefectsTPPage.ClickToDropDownToDeleteDefect();
            DefectsTPPage.ClickToDeleteDefectButtonToDeleteDefect();
            DefectsTPPage.ClickToConfirmDeleteDefectButtonToDeleteDefect();
        }


        public DefectApiModel CreateTestDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.CREATE_DEFECT, Method.Post)
                .AddUrlSegment("code", defect.Code)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);   
        }

        public DefectApiModel GetTestDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.GET_DEFECT)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);                        
        }

        public DefectApiModel UpdateTestDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.UPDATE_DEFECT, Method.Patch)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel DeleteTestDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.DELETE_DEFECT, Method.Delete)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }



        public void DeleteTestDefectByName(string name, string code)
        {
            var listOfDefects = GetAllTestDefect_API(code);

            var testDefects = listOfDefects.Where(testDefect => testDefect.title.Equals(name));

            foreach (var testDefect in testDefects)
            {
                var testDefectForDelete = new Defect
                {
                    Id = testDefect.id.ToString(),
                    Code = code,
                };

                DeleteTestDefect_API(testDefectForDelete);
            }
        }
                

        public List<DefectResult> GetAllTestDefect_API(string code, int limit = 90)
        {
            var request = new RestRequest(Endpoints.GET_ALL_DEFECT)
                 .AddUrlSegment("code", code)
                 .AddParameter("limit", limit);

            var response = _apiClient.Execute<GetAllTestDefect>(request);

            _logger.Info("Defect: " + response.ToString());

            return response.Result.entities;
        }
    }
}
