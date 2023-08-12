using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.UI
{
    public class DefectTests : BaseTest
    {
        [Test]
        public void CreateDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("New Defect_4")
                .SetActualResult("New actual result")
                .Build();
                        
            DefectTPPage.OpenPage();
            Thread.Sleep(2000);
            DefectTPPage.CreateDefect(defect);
            Thread.Sleep(2000);

            Assert.That(DefectTPPage.GetDefectTitle, Is.EqualTo("New Defect_4"));
        }

        [Test]
        public void EditDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("Edit Defect_3")
                .SetActualResult("Edit actual result_1")
                .Build();

            var DefectTPPage = new DefectsTPPage(Driver);

            DefectTPPage.OpenPage();
            Thread.Sleep(2000);
            DefectTPPage.EditDefect(defect);
            Thread.Sleep(2000);

            Assert.That(DefectTPPage.GetDefectTitle, Is.EqualTo("Edit Defect_3"));
        }
    }
}
