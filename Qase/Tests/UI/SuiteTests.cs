using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using Qase.Utilities.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.UI
{
    public class SuiteTests : BaseTest
    {

        [Test, Order(1)]
        [Description("Successful UI test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void CreateSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Suite")
                .SetSuiteDescription("Created suite")
                .SetSuitePreconditions("Precondition")
                .Build();
                        
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            SuiteStepsPage.CreateSuit(suite);
            Thread.Sleep(1000);

            Assert.That(ProjectTPPage.GetSuiteName(), Is.EqualTo(suite.Name));
        }

        [Test, Order(2)]
        [Description("Successful UI test to edit a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void EditSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("EditSuite")
                .Build();
            
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            SuiteStepsPage.EditSuit(suite);
            Thread.Sleep(1000);

            Assert.That(ProjectTPPage.GetSuiteName(), Is.EqualTo(suite.Name));
        }
    }
}
