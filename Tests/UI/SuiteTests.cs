using BusinessObject.Models;
using NUnit.Allure.Attributes;

namespace Tests.UI
{
    public class SuiteTests : BaseTest
    {

        [Test, Order(1)]
        [Description("Successful UI test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void CreateSuiteTest()
        {
            var name = "asdfighcnsidfucg";

            Suite suite = new SuiteBuilder()
                .SetSuiteName(name)
                .SetSuiteDescription("Created suite")
                .SetSuitePreconditions("Precondition")
                .Build();

            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            SuiteStepsPage.CreateSuit(suite);

            Assert.That(ProjectTPPage.GetSuiteNameByText(name), Is.EqualTo(suite.Name));
        }

        [Test, Order(2)]
        [Description("Successful UI test to edit a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
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
    }
}
