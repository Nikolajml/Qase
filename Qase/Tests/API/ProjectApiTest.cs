using NLog;
using Qase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.API
{
    public class ProjectApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
               
        [Test]
        public void CreateProjectTest()
        {           
            var expectedProject = new Project();
            expectedProject.Title = "MyProject";
            expectedProject.Code = "SS";            

            var actualProject = _projectService.CreateProject(expectedProject);
                        
            Console.WriteLine($"Project Code: {actualProject.Code}");
            Console.WriteLine($"Project Name: {actualProject.Title}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedProject.Title, actualProject.Title);
                Assert.AreEqual(expectedProject.Code, actualProject.Code);
            });
        }

        [Test]
        public void GetProjectTest()
        {            
            var project = _projectService.GetProject("PP");

            Console.WriteLine($"Project Code: {project.Code}");
            Console.WriteLine($"Project Name: {project.Title}");

            //Assert.Multiple(() =>
            //{
            //    Assert.AreEqual(expectedProject.Title, actualProject.Title);
            //    Assert.AreEqual(expectedProject.Code, actualProject.Code);
            //});
        }
    }
}
