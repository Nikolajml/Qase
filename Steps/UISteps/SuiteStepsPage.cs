using UI.Models;
using UI.Pages;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class SuiteStepsPage
    {
        public SuitePopUpPage SuitePopUpPage => new SuitePopUpPage(Driver);
        protected IWebDriver Driver;

        public SuiteStepsPage(IWebDriver driver)
        {
            Driver = driver;
        }
       

        public void CreateSuit(Suite suite)
        {
            
            //SuitePopUpPage.OpenPage();
            SuitePopUpPage.IsPageOpened();
            SuitePopUpPage.SetSuiteName(suite.Name);
            SuitePopUpPage.SetSuiteDescriptione(suite.Description);
            SuitePopUpPage.SetSuitePreconditionse(suite.Preconditions);
            SuitePopUpPage.ClickToCreateSuiteButton();
        }

        public void EditSuit(Suite suite)
        {                        
            SuitePopUpPage.IsPageOpened();
            SuitePopUpPage.ClickToClearNameField();
            SuitePopUpPage.ClearNameField();
            SuitePopUpPage.EditSuiteName(suite.Name);
            SuitePopUpPage.ClickToSaveEditButton();
        }
    }
}
