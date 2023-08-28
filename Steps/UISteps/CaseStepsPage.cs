using UI.Models;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class CaseStepsPage : BaseStep
    {
        public CaseStepsPage(IWebDriver driver) : base(driver)
        {
            // Case Page 
        }

        public void CreateCase(Case Case)
        {
            ProjectTPPage.ClickToEllipsis();
            ProjectTPPage.ClickToCaseButton();
            ProjectTPPage.SetCaseName(Case.Title);
            ProjectTPPage.ClickToSaveCaseButton();
        }

        public void EditCase(Case Case)
        {
            ProjectTPPage.ClickToCaseTitle();
            ProjectTPPage.ClickToCaseEdit();
            ProjectTPPage.ClickToCaseTitleField();
            ProjectTPPage.ClearCaseTitleField();
            ProjectTPPage.SetEditedCaseName(Case.Title);
            ProjectTPPage.ClickToSaveCaseButton();
        }
    }
}
