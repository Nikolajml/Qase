using BusinessObject.Models;
using BusinessObject.Pages;
using OpenQA.Selenium;

namespace BusinessObject.Steps
{
    public class SuiteStepsPage : BaseStep
    {
        public SuiteStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public ProjectTPPage CreateSuit(Suite suite)
        {
            ProjectTPPage.ClickToSuiteButton();
            ProjectTPPage.SetSuiteName(suite.Name);
            ProjectTPPage.SetSuiteDescriptione(suite.Description);
            ProjectTPPage.SetSuitePreconditionse(suite.Preconditions);
            ProjectTPPage.ClickToCreateSuiteButton();
            //

            return ProjectTPPage;
        }

        public ProjectTPPage EditSuit(Suite suite)
        {
            ProjectTPPage.ClickToEllipsis();
            ProjectTPPage.ClickToEdit();
            ProjectTPPage.ClickToClearNameField();
            ProjectTPPage.ClearNameField();
            ProjectTPPage.EditSuiteName(suite.Name);
            ProjectTPPage.ClickToSaveEditButton();

            return ProjectTPPage;
        }
    }
}
