using OpenQA.Selenium;
using Qase.Models;
using Qase.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Pages
{
    public class DefectsTPPage : BasePage
    {
        private static string END_POINT = "defect/TP";

        private static readonly By CreateNewDefectButtonBy = By.ClassName("btn-primary");
        private static readonly By DefectTitleInputBy = By.Id("title");
        private static readonly By ActualResultInputBy = By.CssSelector(".toastui-editor-ww-container .gYZSEd");
        private static readonly By SaveDefectButtonBy = By.ClassName("save-button");

        
        
        
        
        private static readonly By AddCasesButtonBy = By.Id("edit-plan-add-cases-button");
        private static readonly By ControlCaseIndicatorBy = By.ClassName("custom-control-indicator");
        private static readonly By DoneButtonBy = By.CssSelector(".CCVJRT .u0i1tV");

        

        private static readonly By EllipsisButtonForPlanEditBy = By.CssSelector(".HWdDFk .ZwgkIF");
        private static readonly By PlanEditButtonBy = By.CssSelector("a[href^='/plan/TP/edit/']");
        private static readonly By PlanTitleInputForClearBy = By.Id("title");
        private static readonly By PlanTitleFieldClearBy = By.Id("title");


        public DefectsTPPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public DefectsTPPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(CreateNewDefectButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }


        // CREATE DEFECTS
        private void ClickToCreateNewDefectButton()
        {
            Driver.FindElement(CreateNewDefectButtonBy).Click();
        }

        private void SetDefectTitle(string defectTitle)
        {
            Driver.FindElement(DefectTitleInputBy).SendKeys(defectTitle);
        }

        private void SetActualresult(string actualResult)
        {
            Driver.FindElement(ActualResultInputBy).SendKeys(actualResult);
        }

        private void ClickToCreateDefectButton()
        {
            Driver.FindElement(SaveDefectButtonBy).Click();
        }

        public DefectsTPPage CreateDefect(Defect defect)
        {
            ClickToCreateNewDefectButton();
            Thread.Sleep(2000);
            SetDefectTitle(defect.DefectTitle);            
            SetActualresult(defect.ActualResult);
            ClickToCreateDefectButton();
            return this;
        }


        // EDIT DEFECTS
        //private void ClickToEllipsis()
        //{
        //    Driver.FindElement(EllipsisButtonForPlanEditBy).Click();
        //}

        //private void ClickToEdit()
        //{
        //    Driver.FindElement(PlanEditButtonBy).Click();
        //}

        //private void ClickToClearTitlePlanField()
        //{
        //    Driver.FindElement(PlanTitleInputForClearBy).Click();
        //}

        //private void ClearTitlePlanField()
        //{
        //    Driver.FindElement(PlanTitleFieldClearBy).Clear();
        //}

        //private void EditPlanTitle(string planTitle)
        //{
        //    Driver.FindElement(PlanTitleInputBy).SendKeys(planTitle);
        //}

        //private void ClickToSaveEditButton()
        //{
        //    Driver.FindElement(SavePlanButtonBy).Click();
        //}

        //public PlanTPPage EditPlan(Plan plan)
        //{
        //    ClickToEllipsis();
        //    ClickToEdit();
        //    Thread.Sleep(2000);
        //    ClickToClearTitlePlanField();
        //    ClearTitlePlanField();
        //    EditPlanTitle(plan.Title);
        //    ClickToSaveEditButton();
        //    return this;
        //}
    }
}
