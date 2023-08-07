using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests
{
    public class DefectTests : BaseTest
    {
        [Test]
        public void CreateDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("New Defect_1")
                .SetActualResult("New actual result")
                .Build();

            var DefectTPPage = new DefectsTPPage(Driver);

            DefectTPPage.OpenPage();
            Thread.Sleep(2000);
            DefectTPPage.CreateDefect(defect);
            Thread.Sleep(2000);

            Assert.True(Driver.FindElement(By.XPath("//a[text()='New Defect_1']")).Displayed);                        
        }
    }
}
