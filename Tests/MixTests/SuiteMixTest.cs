using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.UI;
using UI.Models;

namespace Tests.MixTests
{
    public class SuiteMixTest : BaseTest
    {
        Suite suite { get; set; }
        public List<Suite> SuitesForDelete = new();

        [SetUp]
        public void SetUp()
        {

            suite = new SuiteBuilder()
               .SetSuiteName("New Mix Case UI test")
               .SetSuiteCode("TP")
               .Build();

            var createdTestSuite = _suiteStep.CreateTestSuite(suite);

            suite.Id = createdTestSuite.Result.id.ToString();

            Console.WriteLine(suite.Id);

            SuitesForDelete.Add(suite);
        }


        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditSuiteMixTest()
        {
            suite.Name = "Edited Mix Suite UI test";

            ProjectTPStepsPage.NavigateToEditSuite();
            SuiteStep.EditSuit(suite);

            Assert.That(ProjectTPStepsPage.CreatedSuiteNameForAssert(suite.Name), Is.EqualTo(suite.Name), "Edited Suite Name didn't match");
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var testSuite in SuitesForDelete)
            {
                _suiteStep.DeleteTestSuite(testSuite);
            }
        }
    }
}
