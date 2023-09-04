using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Tests.UI
{
    public class CaseEditTest : BaseTest
    {
        Case Case { get; set; }
        Case CaseForEdit { get; set; }

        //public List<Case> CasesForDelete = new();

        [SetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "TP",
                Title = "Case For EditCaseTest UI"
            };

            _caseStep.CreateTestCase(Case);
        }

        [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
            CaseForEdit = new CaseBuilder()
               .SetCaseTitle("Edited Case UI")
               .Build();

            ProjectTPStepsPage.NavigateToEditCase();
            CaseStep.EditCase(CaseForEdit);

            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(CaseForEdit.Title));
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, Case.Code);
            _caseStep.DeleteTestCaseByName(CaseForEdit.Title, "TP");
        }
    }
}
