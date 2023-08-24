using UI.Models;
using NUnit.Allure.Attributes;

namespace Tests.UI
{
    public class DefectTests : BaseTest
    {
        [Test, Order(1)]
        [Description("Successful UI test to create a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("Defect")
                .SetActualResult("New actual result")
                .Build();

            DefectTPPage.OpenPage();
            DefectTPPage.IsPageOpened();
            DefectStepsPage.CreateDefect(defect);

            cleanUpHandler.DefectsForDelete.Add(defect);

            Assert.That(DefectTPPage.GetDefectTitle, Is.EqualTo(defect.DefectTitle));

            DefectTPPage.ClickToDefectTitleToSecondAssert();

            Assert.That(PlanTPPage.GetPlanDescriptionForSecondAssert(), Is.EqualTo(defect.ActualResult));
        }


        [Test, Order(2)]
        [Description("Successful UI test to edit a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("Edit Defect")
                .SetActualResult("Edit actual result")
                .Build();

            DefectTPPage.OpenPage();
            DefectTPPage.IsPageOpened();
            DefectStepsPage.EditDefect(defect);

            Assert.That(DefectTPPage.GetDefectTitle, Is.EqualTo(defect.DefectTitle));

            DefectTPPage.ClickToDefectTitleToSecondAssert();

            Assert.That(PlanTPPage.GetPlanDescriptionForSecondAssert(), Is.EqualTo(defect.ActualResult));
        }
    }
}
