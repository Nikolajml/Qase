using UI.Models;
using NUnit.Allure.Attributes;
using System.Numerics;
using Bogus;

namespace Tests.UI
{
    public class SuiteTests : BaseTest
    {
        [Test, Order(1)]
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

            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            SuiteStepsPage.CreateSuit(suite);

            Assert.That(ProjectTPPage.GetSuiteNameByText(suite.Name), Is.EqualTo(suite.Name));
        }

        [Test, Order(2)]
        [Description("Successful UI test to edit a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("dkulmfhcifghvel")
                .Build();

            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            SuiteStepsPage.EditSuit(suite);

            Assert.That(ProjectTPPage.GetSuiteNameByText(suite.Name), Is.EqualTo(suite.Name));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            cleanUpHandler.DeleteSuites();
        }
    }
}
