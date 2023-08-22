using UI.Models;
using NUnit.Allure.Attributes;

namespace Tests.UI
{
    public class CaseTests : BaseTest
    {
        [Test, Order(1)]
        [Description("Successful UI test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("New Case Test UI")
                .Build();

            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            CaseStepsPage.CreateCase(Case);

            //Case.Id = CaseStepsPage.GetCaseInfo();
            //entityHandler.CasesForDelete.Add(Case);

            Assert.That(ProjectTPPage.GetCreatedCaseTitle(), Is.EqualTo(Case.Title));
        }

        [Test, Order(2)]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("Edited Case UI")
                .Build();

            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            CaseStepsPage.EditCase(Case);

            Assert.That(ProjectTPPage.GetCreatedCaseTitle(), Is.EqualTo(Case.Title));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            entityHandler.DeleteCases();
        }
    }
}
