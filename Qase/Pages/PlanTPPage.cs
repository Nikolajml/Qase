﻿using OpenQA.Selenium;
using Qase.Core;
using Qase.Models;
using Qase.Tests;
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

        private static readonly By CreatePlanButtonBy = By.Id("createButton");
        private static readonly By PlanTitleInputBy = By.Id("title");
        private static readonly By PlanDescriptionInputBy = By.CssSelector(".ww-mode .ProseMirror");
        
        private static readonly By AddCasesButtonBy = By.Id("edit-plan-add-cases-button");        
        private static readonly By ControlCaseIndicatorBy = By.CssSelector(".suites-column .suite:last-child .custom-control-indicator");
        private static readonly By DoneButtonBy = By.CssSelector(".CCVJRT .u0i1tV");

        private static readonly By SavePlanButtonBy = By.Id("save-plan");

        private static readonly By EllipsisButtonForPlanEditBy = By.CssSelector(".HWdDFk .ZwgkIF");
        private static readonly By PlanEditButtonBy = By.CssSelector("a[href^='/plan/TP/edit/']");        
        private static readonly By PlanTitleInputForClearBy = By.Id("title");
        private static readonly By PlanTitleFieldClearBy = By.Id("title");

        private static readonly By GetPlanTitleBy = By.ClassName("defect-title");


        public PlanTPPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public PlanTPPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(CreatePlanButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }


        // CREATE PLAN
        private void ClickToCreatePlanButton()
        {
            Driver.FindElement(CreatePlanButtonBy).Click();
        }

        private void SetPlanTitle(string planTitle)
        {
            Driver.FindElement(PlanTitleInputBy).SendKeys(planTitle);
        }

        private void SetPlanDescription(string planDescription)
        {
            Driver.FindElement(PlanDescriptionInputBy).SendKeys(planDescription);
        }        

        private void ClickToAddCaseButton()
        {
            Driver.FindElement(AddCasesButtonBy).Click();
        }

        private void ClickToControlIndicatorToChooseCase()
        {
            Driver.FindElement(ControlCaseIndicatorBy).Click();
        }

        private void ClickToDoneButton()
        {
            Driver.FindElement(DoneButtonBy).Click();
        }

        private void ClickToSavePlanButton()
        {
            Driver.FindElement(SavePlanButtonBy).Click();
        }

        public PlanTPPage CreatePlan(Plan plan)
        {
            ClickToCreatePlanButton();
            Thread.Sleep(2000);
            SetPlanTitle(plan.Title);
            SetPlanDescription(plan.Description);
            Thread.Sleep(1000);
            ClickToAddCaseButton();
            Thread.Sleep(1000);
            ClickToControlIndicatorToChooseCase();
            ClickToDoneButton();
            ClickToSavePlanButton();

            return this;
        }


        // EDIT PLAN
        private void ClickToEllipsis()
        {
            Driver.FindElement(EllipsisButtonForPlanEditBy).Click();
        }

        private void ClickToEdit()
        {
            Driver.FindElement(PlanEditButtonBy).Click();
        }

        private void ClickToClearTitlePlanField()
        {
            Driver.FindElement(PlanTitleInputForClearBy).Click();
        }

        private void ClearTitlePlanField()
        {
            Driver.FindElement(PlanTitleFieldClearBy).Clear();
        }

        private void EditPlanTitle(string planTitle)
        {
            Driver.FindElement(PlanTitleInputBy).SendKeys(planTitle);
        }

        private void ClickToSaveEditButton()
        {
            Driver.FindElement(SavePlanButtonBy).Click();
        }

        public PlanTPPage EditPlan(Plan plan)
        {
            ClickToEllipsis();
            ClickToEdit();
            Thread.Sleep(2000);
            ClickToClearTitlePlanField();
            ClearTitlePlanField();
            EditPlanTitle(plan.Title);
            ClickToSaveEditButton();
            return this;
        }


        // METHOD TO ASSERT

        public string GetPlanTitle()
        {
            return Driver.FindElement(GetPlanTitleBy).GetAttribute("innerText");
        }
    }
}
