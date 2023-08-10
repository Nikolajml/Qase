using OpenQA.Selenium;
using Qase.Models;
using Qase.Tests.UI;
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
        private static readonly By ActualResultInputBy = By.CssSelector(".toastui-editor-ww-container .ProseMirror");
        private static readonly By SaveDefectButtonBy = By.ClassName("save-button");
        private static readonly By DefectTitleBy = By.ClassName("defect-title");
        private static readonly By EditDefectButtonBy = By.CssSelector(".me-2 .fa-pen");
        private static readonly By UpdateDefectButtonBy = By.ClassName("save-button");


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
        private void ClickToDefectTitle()
        {
            Driver.FindElement(DefectTitleBy).Click();
        }

        private void ClickToDefectEdit()
        {
            Driver.FindElement(EditDefectButtonBy).Click();
        }

        private void ClickToClearTitleDefectField()
        {
            Driver.FindElement(DefectTitleInputBy).Click();
        }

        private void ClearTitleDefectField()
        {
            Driver.FindElement(DefectTitleInputBy).Clear();
        }

        private void SetEditedDefectTitle(string defectTitle)
        {
            Driver.FindElement(DefectTitleInputBy).SendKeys(defectTitle);
        }

        private void ClickToClearActualResult()
        {
            Driver.FindElement(ActualResultInputBy).Click();
        }

        private void ClearActualResultField()
        {
            Driver.FindElement(ActualResultInputBy).Clear();
        }

        private void SetEditedActualResult(string actualResult)
        {
            Driver.FindElement(ActualResultInputBy).SendKeys(actualResult);
        }

        private void ClickToUpdateDefectButton()
        {
            Driver.FindElement(UpdateDefectButtonBy).Click();
        }

        public DefectsTPPage EditDefect(Defect defect)
        {
            ClickToDefectTitle();
            Thread.Sleep(2000);
            ClickToDefectEdit();
            Thread.Sleep(2000);
            ClickToClearTitleDefectField();
            ClearTitleDefectField();            
            SetEditedDefectTitle(defect.DefectTitle);                     
            ClickToClearActualResult();
            ClearActualResultField();
            SetEditedActualResult(defect.ActualResult);
            ClickToUpdateDefectButton();
            
            return this;
        }


        // METHOD TO ASSERT
        public string GetDefectTitle()
        {
            return Driver.FindElement(DefectTitleBy).GetAttribute("innerText");
        }
    }
}
