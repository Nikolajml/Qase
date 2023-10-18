using Allure.Commons;
using Bogus;
using Core.Client;
using Core.Core;
using Core.Utilities.Configuration;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Steps.Steps;
using UI.Models;

namespace Tests
{
    [AllureNUnit]
    public class CommonBaseTest
    {     
        protected Configurator config;
        protected AllureLifecycle _allure;

        public List<Project> ProjectsForDelete = new List<Project>();
        protected ProjectStep? _projectStep;

        [OneTimeSetUp]
        public void Setup()
        {            
            config = new Configurator();
            _allure = AllureLifecycle.Instance;
        }                           
                                    // оставить только конфигуротра and allure
        [OneTimeTearDown]           // скриншот делать один раз за класс 
        public void TearDown()      // вынести в TearDown часто повторяющиеся действия как Project
        {            
            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep!.DeleteTestProject_API(projectForDelete);
            }

        }
    }
}
