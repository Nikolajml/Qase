using UI.Models;
using UI.Pages;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class SuiteStepsPage : BaseStep
    {
        public SuiteStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public void CreateSuit(Suite suite)
        {
            ProjectTPPage.ClickToSuiteButton();
            ProjectTPPage.SetSuiteName(suite.Name);
            ProjectTPPage.SetSuiteDescriptione(suite.Description);
            ProjectTPPage.SetSuitePreconditionse(suite.Preconditions);
            ProjectTPPage.ClickToCreateSuiteButton();
        }

        public void EditSuit(Suite suite)
        {
            ProjectTPPage.ClickToEllipsis();
            ProjectTPPage.ClickToEdit();
            ProjectTPPage.ClickToClearNameField();
            ProjectTPPage.ClearNameField();
            ProjectTPPage.EditSuiteName(suite.Name);
            ProjectTPPage.ClickToSaveEditButton();
        }
    }
}
