using BusinessObject.Models;
using BusinessObject.Pages;
using OpenQA.Selenium;

namespace BusinessObject.Steps
{
    public class PlanStepsPage : BaseStep
    {
        public PlanStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public PlanTPPage CreatePlan(Plan plan)
        {
            PlanTPPage.ClickToCreatePlanButton();
            PlanTPPage.SetPlanTitle(plan.Title);
            PlanTPPage.SetPlanDescription(plan.Description);
            PlanTPPage.ClickToAddCaseButton();
            PlanTPPage.ClickToControlIndicatorToChooseCase();
            PlanTPPage.ClickToDoneButton();
            PlanTPPage.ClickToSavePlanButton();

            return PlanTPPage;
        }

        public PlanTPPage EditPlan(Plan plan)
        {
            PlanTPPage.ClickToEllipsis();
            PlanTPPage.ClickToEdit();
            PlanTPPage.ClickToClearTitlePlanField();
            PlanTPPage.ClearTitlePlanField();
            PlanTPPage.EditPlanTitle(plan.Title);
            PlanTPPage.ClickToSaveEditButton();

            return PlanTPPage;
        }
    }
}
