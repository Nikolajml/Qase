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
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void CreateSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Test_Suite_Last")
                .SetSuiteDescription("Created suite")
                .SetSuitePreconditions("Precondition")
                .Build();
                        
            ProjectTPPage.OpenPage();
            Thread.Sleep(2000);
            ProjectTPPage.CreateSuit(suite);
            Thread.Sleep(2000);

            Assert.That(ProjectTPPage.GetSuiteName(), Is.EqualTo("Test_Suite_Last Suite"));
        }

        [Test]
        public void EditSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Suite_Edit_Last2")
                .Build();

            var ProjectTPPage = new ProjectTPPage(Driver);

            ProjectTPPage.OpenPage();
            Thread.Sleep(2000);
            ProjectTPPage.EditSuit(suite);
            Thread.Sleep(2000);

            Assert.That(ProjectTPPage.GetSuiteName(), Is.EqualTo("Suite_Edit_Last2"));

        }
    }
}
