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
                .SetSuiteName("Test_Suite_23")
                .SetSuiteDescription("Created suite")
                .SetSuitePreconditions("Precondition")
                .Build();
            
            var ProjectTPPage = new ProjectTPPage(Driver);

            ProjectTPPage.OpenPage();
            Thread.Sleep(2000);
            ProjectTPPage.CreateSuit(suite);
            Thread.Sleep(2000);

            Assert.True(Driver.FindElement(By.XPath("//a[text()='Test_Suite_23']")).Displayed);            
        }

        [Test]
        public void EditSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Suite_Edit")                
                .Build();

            var ProjectTPPage = new ProjectTPPage(Driver);

            ProjectTPPage.OpenPage();
            Thread.Sleep(2000);
            ProjectTPPage.EditSuit(suite);
            Thread.Sleep(2000);

            Assert.True(Driver.FindElement(By.XPath("//a[text()='Suite_Edit']")).Displayed);
        }
    }
}
