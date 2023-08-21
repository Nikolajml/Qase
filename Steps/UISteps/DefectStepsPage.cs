using BusinessObject.Models;
using BusinessObject.Pages;
using OpenQA.Selenium;

namespace BusinessObject.Steps
{
    public class DefectStepsPage : BaseStep
    {
        public DefectStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public DefectsTPPage CreateDefect(Defect defect)
        {
            DefectsTPPage.ClickToCreateNewDefectButton();
            DefectsTPPage.SetDefectTitle(defect.DefectTitle);
            DefectsTPPage.SetActualresult(defect.ActualResult);
            DefectsTPPage.ClickToCreateDefectButton();

            return DefectsTPPage;
        }

        public DefectsTPPage EditDefect(Defect defect)
        {
            DefectsTPPage.ClickToDefectTitle();
            DefectsTPPage.ClickToDefectEdit();
            DefectsTPPage.ClickToClearTitleDefectField();
            DefectsTPPage.ClearTitleDefectField();
            DefectsTPPage.SetEditedDefectTitle(defect.DefectTitle);
            DefectsTPPage.ClickToClearActualResult();
            DefectsTPPage.ClearActualResultField();
            DefectsTPPage.SetEditedActualResult(defect.ActualResult);
            DefectsTPPage.ClickToUpdateDefectButton();

            return DefectsTPPage;
        }
    }
}
