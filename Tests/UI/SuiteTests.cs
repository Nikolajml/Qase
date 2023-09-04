using UI.Models;
using NUnit.Allure.Attributes;
using Bogus;
using Steps.Steps;

namespace Tests.UI
{
    public class SuiteTests : BaseTest
    {
        [Test]
        [Description("Successful UI test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName(Faker.Name.FullName())
                .SetSuiteDescription(Faker.Vehicle.Model())
                .SetSuitePreconditions(Faker.Vehicle.Vin())
                .Build();

            ProjectTPStepsPage.NavigateToCreateSuite();
            SuiteStep.CreateSuit(suite);

            Assert.That(ProjectTPStepsPage.CreatedSuiteNameForAssert(suite.Name), Is.EqualTo(suite.Name));
        }

        [Test]
        [Description("Successful UI test to edit a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Edited Suite")
                .Build();

            //ProjectTPPage.OpenPage();
            //ProjectTPPage.IsPageOpened();
            ProjectTPStepsPage.NavigateToEditSuite();
            SuiteStep.EditSuit(suite);

            //Assert.That(ProjectTPPage.GetSuiteNameByText(suite.Name), Is.EqualTo(suite.Name));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //cleanUpHandler.DeleteSuites();
        }
    }
}
