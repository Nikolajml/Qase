using UI.Models;
using OpenQA.Selenium;
using UI.Pages;

namespace Steps.UISteps
{
    public class CaseStepsPage
    {
        public CasePage CasePage => new CasePage(Driver);
        protected IWebDriver Driver;

        public CaseStepsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CreateCase(Case Case)
        {            
            CasePage.IsPageOpened();            
            CasePage.SetCaseName(Case.Title);
            CasePage.ClickToSaveCaseButton();
        }


        public void EditCase(Case Case)
        {            
            CasePage.ClickToCaseTitleField();
            CasePage.ClearCaseTitleField();
            CasePage.SetEditedCaseName(Case.Title);
            CasePage.ClickToSaveCaseButton();
        }


        


    }
}
