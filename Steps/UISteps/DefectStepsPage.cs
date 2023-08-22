using UI.Models;
using UI.Pages;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class DefectStepsPage : BaseStep
    {
        public DefectStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public void CreateDefect(Defect defect)
        {
            DefectsTPPage.ClickToCreateNewDefectButton();
            DefectsTPPage.SetDefectTitle(defect.DefectTitle);
            DefectsTPPage.SetActualresult(defect.ActualResult);
            DefectsTPPage.ClickToCreateDefectButton();
        }

        public void EditDefect(Defect defect)
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
        }
    }
}
