using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ProjectBuilder
    {
        private Project project;

        public ProjectBuilder()
        {
            project = new Project();
        }

        public ProjectBuilder SetPlanTitle(string title)
        {
            project.Title = title;
            return this;
        }

        public ProjectBuilder SetPlanDescription(string description)
        {
            project.Description = description;
            return this;
        }                

        public Project Build()
        {
            return project;
        }
    }
}
