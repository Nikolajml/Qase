using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using Qase.Utilities.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests
{
    public class CreateSuiteTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {            
            LoginPage.TryToLogin(Configurator.Admin);
            Thread.Sleep(2000);
        }

        [Test]
        public void CreateNewSuiteTest()
        {            
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Test_Suite_23")
                .SetSuiteDescription("Created suite")
                .SetSuitePreconditions("Precondition")
                .Build();
            
            var ProjectTPPage = new ProjectTPPage(Driver);

            ProjectTPPage.OpenPage();
            Thread.Sleep(2000);
            ProjectTPPage.CreateSuit(suite);                       

            Assert.True(Driver.FindElement(By.XPath("//a[text()='Test_Suite_23']")).Displayed);
        }
    }
}
