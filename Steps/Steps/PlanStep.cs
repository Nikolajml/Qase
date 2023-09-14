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
    public class PlanStep
    {
        public PlanTPPage PlanTPPage;
        protected ApiClient _apiClient;        
        protected ILogger _logger;        

        public PlanStep(ILogger logger, IWebDriver driver = null, ApiClient apiClient = null)
        {
            if (driver != null)
            {
                PlanTPPage = new PlanTPPage(logger, driver);
            }

            if (apiClient != null)
            {
                _apiClient = apiClient;
            }

            _logger = logger;
        }


        public void NavigateToPlanPage()
        {
            PlanTPPage.OpenPage();
            //PlanTPPage.IsPageOpened();
        }

        public void CreatePlan(Plan plan)
        {            
            PlanTPPage.ClickToCreatePlanButton();
            PlanTPPage.SetPlanTitle(plan.Title);
            PlanTPPage.SetPlanDescription(plan.Description);
            PlanTPPage.ClickToAddCaseButton();
            PlanTPPage.ClickToControlIndicatorToChooseCase();
            PlanTPPage.ClickToDoneButton();
            PlanTPPage.ClickToSavePlanButton();
        }

        public string CreatedPlanTitleForFirstAssert()
        {
            return PlanTPPage.GetPlanTitle();
        }

        public void NavigateToCreatedPlanForSecondAssert()
        {
            PlanTPPage.ClickToCreatedPlanTitleToAssert();
        }

        public string CreatedPlanTitleForSecondAssert()
        {
            return PlanTPPage.GetPlanTitleForSecondAssert();
        }

        public string CreatedPlanDescriptionForSecondAssert()
        {
            return PlanTPPage.GetPlanDescriptionForSecondAssert();
        }

        public void EditPlan(Plan plan)
        {            
            PlanTPPage.ClickToEllipsis();
            PlanTPPage.ClickToEdit();
            PlanTPPage.ClickToClearTitlePlanField();
            PlanTPPage.ClearTitlePlanField();
            PlanTPPage.EditPlanTitle(plan.Title);
            PlanTPPage.ClickToSaveEditButton();
        }

        public void DeletePlan_UI()
        {
            PlanTPPage.DeletePlan();
        }


        //public PlanStep(ApiClient apiClient)
        //{
        //    _apiClient = apiClient;
        //}

        public PlanApiModel CreateTestPlan_API(Plan plan)
        {
            var request = new RestRequest(Endpoints.CREATE_PLAN, Method.Post)
                .AddUrlSegment("code", plan.Code)
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel GetTestPlan_API(Plan plan)
        {
            var request = new RestRequest(Endpoints.GET_PLAN)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", plan.Id)
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel UpdateTestPlan_API(Plan plan)
        {
            var request = new RestRequest(Endpoints.UPDATE_PLAN, Method.Patch)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", plan.Id)
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel DeleteTestPlan_API(Plan plan)
        {
            var request = new RestRequest(Endpoints.DELETE_PLAN, Method.Delete)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", plan.Id)
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }
    }
}
