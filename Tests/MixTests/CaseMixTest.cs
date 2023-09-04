using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using Tests.UI;

namespace Tests.MixTests
{
    public class CaseMixTest : BaseTest
    {
        Case Case { get; set; }
        public List<Case> CasesForDelete = new();

        [SetUp]
        public void SetUp()
        {

            Case = new CaseBuilder()
               .SetCaseTitle("MIX TEST CASE Test")
               .SetCode("TP")
               .Build();

            var createdTestCase = _caseStep.CreateTestCase(Case);

            Case.Id = createdTestCase.Result.id.ToString();

            Console.WriteLine(Case.Id);

            CasesForDelete.Add(Case);
        }


        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseMixTest()
        {
            Case.Title = "Edited Case UI";

            ProjectTPStepsPage.NavigateToEditCase();
            CaseStep.EditCase(Case);

            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "Edited Case Title didn't match");
        }
           

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var testCace in CasesForDelete)
            {
                _caseStep.DeleteTestCase(testCace);
            }
        }
    }
}
