using UI.Models;
using UI.Pages;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class PlanStepsPage : BaseStep
    {
        public PlanStepsPage(IWebDriver driver) : base(driver)
        {

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

        public void EditPlan(Plan plan)
        {
            PlanTPPage.ClickToEllipsis();
            PlanTPPage.ClickToEdit();
            PlanTPPage.ClickToClearTitlePlanField();
            PlanTPPage.ClearTitlePlanField();
            PlanTPPage.EditPlanTitle(plan.Title);
            PlanTPPage.ClickToSaveEditButton();
        }
    }
}
