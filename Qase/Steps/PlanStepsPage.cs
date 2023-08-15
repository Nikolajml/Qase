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
            //Thread.Sleep(2000);            
            PlanTPPage.ClickToAddCaseButton();
            //Thread.Sleep(2000);
            PlanTPPage.ClickToControlIndicatorToChooseCase();            
            PlanTPPage.ClickToDoneButton();
            PlanTPPage.ClickToSavePlanButton();

            return PlanTPPage;
        }

        public PlanTPPage EditPlan(Plan plan)
        {
            PlanTPPage.ClickToEllipsis();
            PlanTPPage.ClickToEdit();
            //Thread.Sleep(2000);
            PlanTPPage.WaitOpenPlanDetailsToInput();
            PlanTPPage.ClickToClearTitlePlanField();
            PlanTPPage.ClearTitlePlanField();
            PlanTPPage.EditPlanTitle(plan.Title);
            PlanTPPage.ClickToSaveEditButton();
            
            return PlanTPPage;
        }
    }
}
