using Core.Core;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.UI;
using UI.Models;

namespace Tests.MixTests
{
    public class DefectMixTest : CommonBaseTest
    {
        Defect defect { get; set; }

        public List<Defect> DefectsForDelete = new List<Defect>();
        public DefectStep _defectStep;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            _defectStep = new DefectStep(logger, Driver, _apiClient);
        }

        [SetUp]
        public void SetUp()
        {
            defect = new DefectBuilder()
               .SetDefectTitle("Mix Defect UI test")
               .SetActualResult("Some reuslt for defrect")
               .SetCode("TP")
               .Build();

            var createdTestDefect = _defectStep.CreateTestDefect_API(defect);

            defect.Id = createdTestDefect.Result.id.ToString();

            Console.WriteLine(defect.Id);

            DefectsForDelete.Add(defect);
        }

        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditDefectMixTest()
        {
            defect.DefectTitle = "Edited Mix Defect UI test";

            //_defectStep.NavigateToDefectCase();
            _defectStep.EditDefect_UI(defect);
            Assert.That(_defectStep.DefectTitleForFirstAssert_UI, Is.EqualTo(defect.DefectTitle), "Edited Defect Title didn't match");

            _defectStep.NavigateToCreatedDefectForSecondAssert_UI();
            Assert.That(_defectStep.DefectDescriptionForSecondAssert_UI(), Is.EqualTo(defect.ActualResult), "Edited Defect Description didn't match");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var testSuite in DefectsForDelete)
            {
                _defectStep.DeleteTestDefect_API(testSuite);
            }
        }
    }
}
