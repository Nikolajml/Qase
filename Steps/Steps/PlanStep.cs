using API.ResponseAPIModels;
using API.Services;
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
        public PlanService PlanService;
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

            if (apiClient != null)
            {
                PlanService = new PlanService(logger, apiClient);
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
                

        public PlanApiModel CreateTestPlan_API(Plan plan)
        {
            var response = PlanService.CreatePlan_API(plan);

            return response;
        }

        public PlanApiModel GetTestPlan_API(Plan plan)
        {
            var response = PlanService.GetPlan_API(plan);

            return response;
        }

        public PlanApiModel UpdateTestPlan_API(Plan plan)
        {
            var response = PlanService.UpdatePlan_API(plan);

            return response;
        }

        public PlanApiModel DeleteTestPlan_API(Plan plan)
        {
            var response = PlanService.DeletePlan_API(plan);

            return response;
        }
    }
}
