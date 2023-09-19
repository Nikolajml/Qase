using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using Core.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
        public DefectService DefectService;
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

            if (apiClient != null)
            {
                DefectService = new DefectService(logger, apiClient);
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
            var response = DefectService.CreateDefect_API(defect);                         // сделать логер частью Page and Service

            return response;
        }

        public DefectApiModel GetTestDefect_API(Defect defect)
        {
            var response = DefectService.GetDefect_API(defect);

            return response;
        }

        public DefectApiModel UpdateTestDefect_API(Defect defect)
        {
            var response = DefectService.UpdateDefect_API(defect);

            return response;
        }

        public DefectApiModel DeleteTestDefect_API(Defect defect)
        {
            var response = DefectService.DeleteDefect_API(defect);

            return response;
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
                

        public List<DefectResult> GetAllTestDefect_API(string code)
        {
            var request = new RestRequest(Endpoints.GET_ALL_DEFECT)
                 .AddUrlSegment("code", code)
                 .AddParameter("limit", 90);

            var response = _apiClient.Execute<GetAllTestDefect>(request);

            _logger.Info("Defect: " + response.ToString());

            return response.Result.entities;
        }
    }
}
