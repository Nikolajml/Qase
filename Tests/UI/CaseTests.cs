using UI.Models;
using NUnit.Allure.Attributes;
using Steps.UISteps;

namespace Tests.UI
{
    public class CaseTests : BaseTest
    {
        Case Case;
        List<string> testCaseName;


        [SetUp]
        public void Setup()
        {

            Case = new Case()
            {
                Code = "OSDUIFHSIUDISDUHFISUDHFISUDHFISUHDFISUDHFIUSDHF&#G*P&SGDHP&*SDE",
                Title = "Case_api_New"
            };

            var createdTestCase = _caseStep.CreateTestCase(Case);

            Case.Id = createdTestCase.Result.id.ToString();

            Console.WriteLine(Case.Id);

            //CreateCaseTest

        }



        [Test]
        [Description("Successful UI test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateCaseTest()
        {
            Case = new CaseBuilder()
                .SetCaseTitle("NIKOLAY_SUPER")
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();
            CaseStepsPage.CreateCase(Case);
            testCaseName.Add(Case.Title);


            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title));
        }

      /*  [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
             Case = new CaseBuilder()
                .SetCaseTitle("Edited Case UI")
                .Build();

            ProjectTPStepsPage.NavigateToEditCase();
            CaseStepsPage.EditCase(Case);

            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title));
        }*/

        [TearDown]
        public void TearDown()
        {
            //testCaseName
            _caseStep.DeleteTestCaseByName(Case.Title, "TP");
        }
    }
}
