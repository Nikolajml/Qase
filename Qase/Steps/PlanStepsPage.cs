using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Steps
{
    public class PlanStepsPage : BaseStep
    {
        public PlanStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public PlanTPPage CreatePlan(Plan plan)
        {
            PlanTPPage.ClickToCreatePlanButton();
            PlanTPPage.WaitOpenPlanDetailsToInput();
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
            PlanTPPage.WaitOpenPlanDetailsToInput();
            PlanTPPage.ClickToClearTitlePlanField();
            PlanTPPage.ClearTitlePlanField();
            PlanTPPage.EditPlanTitle(plan.Title);
            PlanTPPage.ClickToSaveEditButton();

            return PlanTPPage;
        }
    }
}
