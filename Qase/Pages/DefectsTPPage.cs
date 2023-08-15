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

        private readonly By CreateNewDefectButtonBy = By.XPath("//*[@class='btn btn-primary']");
        private readonly By DefectTitleInputBy = By.XPath("//*[@id='title']");
        private readonly By ActualResultInputBy = By.CssSelector(".toastui-editor-ww-container .ProseMirror");
        private readonly By SaveDefectButtonBy = By.XPath("//button[@class='btn btn-primary me-3 save-button']");
        private readonly By DefectTitleBy = By.XPath("//*[@class='defect-title']"); 
        private readonly By EditDefectButtonBy = By.XPath("//*[@class='fa fa-pen']");
        private readonly By UpdateDefectButtonBy = By.XPath("//*[@class='btn btn-primary me-3 save-button']");
        private readonly By DefectTitleForSecondAssertBy = By.XPath("//*[@class='col-lg-12']");   
        private readonly By DefectDescriptionForSecondAssertBy = By.XPath("//*[@class='toastui-editor-contents']");


        //private readonly By CreateNewDefectButtonBy = By.XPath("//*[@class='btn btn-primary']");  //btn btn-primary
        //private readonly By DefectTitleInputBy = By.XPath("//*[@id='title']");
        //private readonly By ActualResultInputBy = By.XPath("//div[@class='toastui-editor-ww-container']");
        //private readonly By SaveDefectButtonBy = By.XPath("//button[@class='btn btn-primary me-3 save-button']");
        //private readonly By DefectTitleBy = By.XPath("//*[@class='defect-title']"); //*[@class="save-button"]
        //private readonly By EditDefectButtonBy = By.XPath("//*[@class='fa fa-pen']");
        //private readonly By UpdateDefectButtonBy = By.XPath("//*[@class='save-button']"); // replace with XPath  

        //private readonly By DefectTitleForSecondAssertBy = By.XPath("//*[@class='col-lg-12']");
        //private readonly By DefectDescriptionForSecondAssertBy = By.XPath("//*[@class='toastui-editor-contents']");

        // Сделать через проперти

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
        public void ClickToCreateNewDefectButton()
        {
            Driver.FindElement(CreateNewDefectButtonBy).Click();
        }

        public void SetDefectTitle(string defectTitle)
        {
            Driver.FindElement(DefectTitleInputBy).SendKeys(defectTitle);
        }

        public void SetActualresult(string actualResult)
        {
            Driver.FindElement(ActualResultInputBy).SendKeys(actualResult);
        }

        public void ClickToCreateDefectButton()
        {
            Driver.FindElement(SaveDefectButtonBy).Click();
        }

        // WAIT FOR CREATE DEFECT
        
        public bool WaitCreateDefect()
        {
            return WaitService.GetVisibleElement(DefectTitleInputBy) != null;
        }




        // WAIT FOR SECOND ASSERT
        public bool WaitDefect()
        {
            return WaitService.GetVisibleElement(DefectTitleBy) != null;
        }

        public bool WaitDefectDescription()
        {
            return WaitService.GetVisibleElement(DefectDescriptionForSecondAssertBy) != null;
        }

        // METHODS FOR SECOND ASSERT

        public void ClickToDefectTitleToSecondAssert()
        {
            Driver.FindElement(DefectTitleBy).Click();
        }
        

        public string GetDefectTitleForSecondAssert()
        {
            return Driver.FindElement(DefectTitleForSecondAssertBy).Text;
        }

        public string GetDefectDescriptionForSecondAssert()
        {
            return Driver.FindElement(DefectDescriptionForSecondAssertBy).Text;
        }





        // EDIT DEFECTS
        public void ClickToDefectTitle()
        {
            Driver.FindElement(DefectTitleBy).Click();
        }

        public void ClickToDefectEdit()
        {
            Driver.FindElement(EditDefectButtonBy).Click();
        }

        public void ClickToClearTitleDefectField()
        {
            Driver.FindElement(DefectTitleInputBy).Click();
        }

        public void ClearTitleDefectField()
        {
            Driver.FindElement(DefectTitleInputBy).Clear();
        }

        public void SetEditedDefectTitle(string defectTitle)
        {
            Driver.FindElement(DefectTitleInputBy).SendKeys(defectTitle);
        }

        public void ClickToClearActualResult()
        {
            Driver.FindElement(ActualResultInputBy).Click();
        }

        public void ClearActualResultField()
        {
            Driver.FindElement(ActualResultInputBy).Clear();
        }

        public void SetEditedActualResult(string actualResult)
        {
            Driver.FindElement(ActualResultInputBy).SendKeys(actualResult);
        }

        public void ClickToUpdateDefectButton()
        {
            Driver.FindElement(UpdateDefectButtonBy).Click();
        }
                

        // METHOD TO ASSERT
        public string GetDefectTitle()
        {
            return Driver.FindElement(DefectTitleBy).GetAttribute("innerText");
        }
    }
}
