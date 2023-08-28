using UI.Models;
using UI.Pages;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class PlanStepsPage
    {
        public PlanTPPage PlanTPPage => new PlanTPPage(Driver);
        protected IWebDriver Driver;
        public PlanStepsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CreatePlan(Plan plan)
        {
            PlanTPPage.OpenPage();
            PlanTPPage.IsPageOpened();
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
            PlanTPPage.OpenPage();
            PlanTPPage.IsPageOpened();
            PlanTPPage.ClickToEllipsis();
            PlanTPPage.ClickToEdit();
            PlanTPPage.ClickToClearTitlePlanField();
            PlanTPPage.ClearTitlePlanField();
            PlanTPPage.EditPlanTitle(plan.Title);
            PlanTPPage.ClickToSaveEditButton();
        }
    }
}
