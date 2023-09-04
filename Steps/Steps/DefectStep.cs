using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using NLog;
using OpenQA.Selenium;
using RestSharp;
using UI.Models;
using UI.Pages;

namespace Steps.Steps
{
    public class DefectStep // не должно быть наследования в DefectSteps
    {
        public DefectsTPPage DefectsTPPage => new DefectsTPPage(Driver);
        protected IWebDriver Driver;

        public DefectStep(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CreateDefect(Defect defect)
        {
            DefectsTPPage.OpenPage();
            DefectsTPPage.IsPageOpened();
            DefectsTPPage.ClickToCreateNewDefectButton();
            DefectsTPPage.SetDefectTitle(defect.DefectTitle);
            DefectsTPPage.SetActualresult(defect.ActualResult);
            DefectsTPPage.ClickToCreateDefectButton();
        }

        public string DefectTitleForFirstAssert()
        {
            return DefectsTPPage.GetDefectTitle();
        }

        public void NavigateToCreatedDefectForSecondAssert()
        {
            DefectsTPPage.ClickToDefectTitleToSecondAssert();
        }

        public string DefectTitleForSecondAssert()
        {
            return DefectsTPPage.GetDefectTitleForSecondAssert();
        }

        public string DefectDescriptionForSecondAssert()
        {
            return DefectsTPPage.GetDefectDescriptionForSecondAssert();
        }

        public void NavigateToDefectCase()
        {
            DefectsTPPage.OpenPage();
            DefectsTPPage.IsPageOpened();
        }

        public void EditDefect(Defect defect)
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







        protected ApiClient _apiClient;

        protected Logger _logger = LogManager.GetCurrentClassLogger();

        public DefectStep(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public DefectApiModel CreateTestDefect(Defect defect)
        {
            var request = new RestRequest(Endpoints.CREATE_DEFECT, Method.Post)
                .AddUrlSegment("code", defect.Code)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);   
        }

        public DefectApiModel GetTestDefect(Defect defect)
        {
            var request = new RestRequest(Endpoints.GET_DEFECT)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);                        
        }

        public DefectApiModel UpdateTestDefect(Defect defect)
        {
            var request = new RestRequest(Endpoints.UPDATE_DEFECT, Method.Patch)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel DeleteTestDefect(Defect defect)
        {
            var request = new RestRequest(Endpoints.DELETE_DEFECT, Method.Delete)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }
    }

    
}
