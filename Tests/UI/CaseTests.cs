using UI.Models;
using NUnit.Allure.Attributes;
using Steps.UISteps;

namespace Tests.UI
{
    public class CaseTests : BaseTest
    {
        [Test]
        [Description("Successful UI test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("New Case Test UI")
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();
            CaseStepsPage.CreateCase(Case);

            //Case.Id = CaseStepsPage.GetCaseInfo();
            //entityHandler.CasesForDelete.Add(Case);

            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title));
        }

        [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("Edited Case UI")
                .Build();

            ProjectTPStepsPage.NavigateToEditCase();
            CaseStepsPage.EditCase(Case);

            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            cleanUpHandler.DeleteCases();
        }
    }
}
