using OpenQA.Selenium;
using Qase.Core;
using Qase.Models;
using Qase.Tests.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Pages
{
    public  class PlanTPPage : BasePage
    {
        private static string END_POINT = "plan/TP";              

        private readonly By CreatePlanButtonBy = By.XPath("//a[@id='createButton']");
        private readonly By PlanTitleInputBy = By.XPath("//input[@id='title']");     //("title");
        private readonly By PlanDescriptionInputBy = By.CssSelector(".ww-mode .ProseMirror");
        private readonly By AddCasesButtonBy = By.XPath("//button[@id='edit-plan-add-cases-button']");       //Id("edit-plan-add-cases-button");        
        private readonly By ControlCaseIndicatorBy = By.CssSelector(".suites-column .suite:last-child .custom-control-indicator");
        private readonly By DoneButtonBy = By.CssSelector(".CCVJRT .u0i1tV");
        private readonly By SavePlanButtonBy = By.Id("save-plan");
        private readonly By EllipsisButtonForPlanEditBy = By.CssSelector(".HWdDFk .ZwgkIF");
        private readonly By PlanEditButtonBy = By.CssSelector("a[href^='/plan/TP/edit/']");        
        private readonly By PlanTitleInputForClearBy = By.Id("title");
        private readonly By PlanTitleFieldClearBy = By.Id("title");
        private readonly By GetPlanTitleBy = By.ClassName("defect-title");

        private readonly By GetPlanTitleForSecondAssertBy = By.ClassName("plan-view-header-title");
        private readonly By GetPlanDescriptionForSecondAssertBy = By.ClassName("toastui-editor-contents");


        public PlanTPPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public PlanTPPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(EllipsisButtonForPlanEditBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }


        // CREATE PLAN
        public void ClickToCreatePlanButton()
        {
            Driver.FindElement(CreatePlanButtonBy).Click();
        }

        public void SetPlanTitle(string planTitle)
        {
            Driver.FindElement(PlanTitleInputBy).SendKeys(planTitle);
        }

        public void SetPlanDescription(string planDescription)
        {
            Driver.FindElement(PlanDescriptionInputBy).SendKeys(planDescription);
        }

        public void ClickToAddCaseButton()
        {
            Driver.FindElement(AddCasesButtonBy).Click();
        }

        public void ClickToControlIndicatorToChooseCase()
        {
            Driver.FindElement(ControlCaseIndicatorBy).Click();
        }

        public void ClickToDoneButton()
        {
            Driver.FindElement(DoneButtonBy).Click();
        }

        public void ClickToSavePlanButton()
        {
            Driver.FindElement(SavePlanButtonBy).Click();
        }

        // Second assert for created Plan

        public void ClickToCreatedPlanTitleToAssert()
        {
            Driver.FindElement(GetPlanTitleBy).Click();
        }

        public string GetPlanTitleForSecondAssert()
        {
            return Driver.FindElement(GetPlanTitleForSecondAssertBy).Text;
        }

        public string GetPlanDescriptionForSecondAssert()
        {
            return Driver.FindElement(GetPlanDescriptionForSecondAssertBy).GetAttribute("innerText");
        }

        public bool WaitPlan()
        {
            return WaitService.GetVisibleElement(GetPlanTitleBy) != null;
        }

        public bool WaitOpenPlanDetails()
        {
            return WaitService.GetVisibleElement(GetPlanTitleForSecondAssertBy) != null;
        }

        // WaitService for Create Plan

        public bool WaitOpenPlanDetailsToInput()
        {
            return WaitService.GetVisibleElement(PlanTitleInputBy) != null;
        }


        




        // EDIT PLAN
        public void ClickToEllipsis()
        {
            Driver.FindElement(EllipsisButtonForPlanEditBy).Click();
        }

        public void ClickToEdit()
        {
            Driver.FindElement(PlanEditButtonBy).Click();
        }

        public void ClickToClearTitlePlanField()
        {
            Driver.FindElement(PlanTitleInputForClearBy).Click();
        }

        public void ClearTitlePlanField()
        {
            Driver.FindElement(PlanTitleFieldClearBy).Clear();
        }

        public void EditPlanTitle(string planTitle)
        {
            Driver.FindElement(PlanTitleInputBy).SendKeys(planTitle);
        }

        public void ClickToSaveEditButton()
        {
            Driver.FindElement(SavePlanButtonBy).Click();
        }

        


        // METHOD TO ASSERT

        public string GetPlanTitle()
        {
            return Driver.FindElement(GetPlanTitleBy).GetAttribute("innerText");
        }
    }
}
