using Core.Utilities.Configuration;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class DefectsTPPage : BasePage
    {
        private static string END_POINT = "defect/TP";                

        private IWebElement CreateNewDefectButtonBy => Driver.FindElement(By.XPath("//*[@class='btn btn-primary']"));
        private IWebElement DefectTitleInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement ActualResultInputBy => Driver.FindElement(By.CssSelector(".toastui-editor-ww-container .ProseMirror"));
        private IWebElement SaveDefectButtonBy => Driver.FindElement(By.XPath("//button[@class='btn btn-primary me-3 save-button']"));
        private IWebElement DefectTitleBy => Driver.FindElement(By.XPath("//*[@class='defect-title']"));
        private IWebElement EditDefectButtonBy => Driver.FindElement(By.XPath("//*[@class='fa fa-pen']"));
        private IWebElement UpdateDefectButtonBy => Driver.FindElement(By.XPath("//*[@class='btn btn-primary me-3 save-button']"));
        private IWebElement DefectTitleForSecondAssertBy => Driver.FindElement(By.XPath("//*[@class='col-lg-12']"));
        private IWebElement DefectDescriptionForSecondAssertBy => Driver.FindElement(By.XPath("//*[@class='toastui-editor-contents']"));
        private IWebElement DeleteDefectDropDown => Driver.FindElement(By.XPath("//button[@class='j4xaa7 bB3U2Y TuZZEp']"));
        private IWebElement DeleteDefectButton => Driver.FindElement(By.XPath("//button[@class='KXyzbV IhDC1_ rHqCyR']"));
        private IWebElement ConfirmDeleteDefectButton => Driver.FindElement(By.XPath("//button[@class='j4xaa7 b_jd28 J4xngT']"));


        public DefectsTPPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public DefectsTPPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return CreateNewDefectButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(new Configurator().AppSettings.URL + END_POINT);
        }


        // CREATE DEFECTS
        public void ClickToCreateNewDefectButton()
        {
            CreateNewDefectButtonBy.Click();
        }

        public void SetDefectTitle(string defectTitle)
        {
            DefectTitleInputBy.SendKeys(defectTitle);
        }

        public void SetActualresult(string actualResult)
        {
            ActualResultInputBy.SendKeys(actualResult);
        }


        public void ClickToCreateDefectButton()
        {
            SaveDefectButtonBy.Click();
        }

        // METHODS FOR SECOND ASSERT
        public void ClickToDefectTitleToSecondAssert()
        {
            DefectTitleBy.Click();
        }

        public string GetDefectTitleForSecondAssert()
        {
            return DefectTitleForSecondAssertBy.Text;
        }

        public string GetDefectDescriptionForSecondAssert()
        {
            return DefectDescriptionForSecondAssertBy.Text;
        }

        // EDIT DEFECTS
        public void ClickToDefectTitle()
        {
            DefectTitleBy.Click();
        }

        public void ClickToDefectEdit()
        {
            EditDefectButtonBy.Click();
        }

        public void ClickToClearTitleDefectField()
        {
            DefectTitleInputBy.Click();
        }
        public void ClearTitleDefectField()
        {
            DefectTitleInputBy.Clear();
        }

        public void SetEditedDefectTitle(string defectTitle)
        {
            DefectTitleInputBy.SendKeys(defectTitle);
        }

        public void ClickToClearActualResult()
        {
            ActualResultInputBy.Click();
        }

        public void ClearActualResultField()
        {
            ActualResultInputBy.Clear();
        }

        public void SetEditedActualResult(string actualResult)
        {
            ActualResultInputBy.SendKeys(actualResult);
        }
        public void ClickToUpdateDefectButton()
        {
            UpdateDefectButtonBy.Click();
        }

        // METHOD TO ASSERT
        public string GetDefectTitle()
        {
            return DefectTitleBy.GetAttribute("innerText");
        }

        //Method for delete Defect

        public void ClickToDropDownToDeleteDefect()
        {
            DeleteDefectDropDown.Click();
        }

        public void ClickToDeleteDefectButtonToDeleteDefect()
        {
            DeleteDefectButton.Click();
        }

        public void ClickToConfirmDeleteDefectButtonToDeleteDefect()
        {
            ConfirmDeleteDefectButton.Click();
        }
    }
}
