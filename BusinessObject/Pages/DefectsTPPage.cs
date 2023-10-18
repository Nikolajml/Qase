using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class DefectsTPPage : BasePage
    {
        private const string END_POINT = "defect/TP";                

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


        public DefectsTPPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }
        public DefectsTPPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"Defects Page opened status: {CreateNewDefectButtonBy.Displayed}");
            return CreateNewDefectButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }


        // CREATE DEFECTS
        public void ClickToCreateNewDefectButton()
        {
            _logger.Debug($"Click to create defect button");
            CreateNewDefectButtonBy.Click();
        }

        public void SetDefectTitle(string defectTitle)
        {
            _logger.Debug($"Set a defect title: {defectTitle}");
            DefectTitleInputBy.SendKeys(defectTitle);
        }

        public void SetActualresult(string actualResult)
        {
            _logger.Debug($"Set actual result for the defect: {actualResult}");
            ActualResultInputBy.SendKeys(actualResult);
        }


        public void ClickToCreateDefectButton()
        {
            _logger.Debug($"Click Create Defect Button");
            SaveDefectButtonBy.Click();
        }

        // Methods for seconds assert
        public void ClickToDefectTitleToSecondAssert()
        {
            _logger.Debug($"Click to defect title for second assert");
            DefectTitleBy.Click();
        }

        public string GetDefectTitleForSecondAssert()
        {
            _logger.Debug($"Get defect title for second assert");
            return DefectTitleForSecondAssertBy.Text;
        }

        public string GetDefectDescriptionForSecondAssert()
        {
            _logger.Debug($"Get defect description for second assert");
            return DefectDescriptionForSecondAssertBy.Text;
        }

        // Eedit defect
        public void ClickToDefectTitle()
        {
            _logger.Debug($"Click to defect title for edit");
            DefectTitleBy.Click();
        }

        public void ClickToDefectEdit()
        {
            _logger.Debug($"Click to defect edit");
            EditDefectButtonBy.Click();
        }

        public void ClickToClearTitleDefectField()
        {
            _logger.Debug($"Click to clear defect title");
            DefectTitleInputBy.Click();
        }
        public void ClearTitleDefectField()
        {
            _logger.Debug($"Clear defect title");
            DefectTitleInputBy.Clear();
        }

        public void SetEditedDefectTitle(string defectTitle)
        {
            _logger.Debug($"Set edited defect title: {defectTitle}");
            DefectTitleInputBy.SendKeys(defectTitle);
        }

        public void ClickToClearActualResult()
        {
            _logger.Debug($"Ckick to clear actual result");
            ActualResultInputBy.Click();
        }

        public void ClearActualResultField()
        {
            _logger.Debug($"Clear actual result");
            ActualResultInputBy.Clear();
        }

        public void SetEditedActualResult(string actualResult)
        {
            _logger.Debug($"Set edited actual result: {actualResult}");
            ActualResultInputBy.SendKeys(actualResult);
        }
        public void ClickToUpdateDefectButton()
        {
            _logger.Debug($"Cleck to update actual result for defect");
            UpdateDefectButtonBy.Click();
        }

        // Method for assert
        public string GetDefectTitle()
        {
            _logger.Debug($"Get defect title for assert");
            return DefectTitleBy.GetAttribute("innerText");
        }

        //Method for delete Defect
        public void ClickToDropDownToDeleteDefect()
        {
            _logger.Debug($"Click on the DropDown to delete defect");
            DeleteDefectDropDown.Click();
        }

        public void ClickToDeleteDefectButtonToDeleteDefect()
        {
            _logger.Debug($"Click on the DeleteDefect Button to delete defect");
            DeleteDefectButton.Click();
        }

        public void ClickToConfirmDeleteDefectButtonToDeleteDefect()
        {
            _logger.Debug($"Click on the ConfirmDeleteButton to delete defect");
            ConfirmDeleteDefectButton.Click();
        }
    }
}
