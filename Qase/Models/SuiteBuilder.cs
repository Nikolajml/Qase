using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class SuiteBuilder
    {
        private Suite suite;

        public SuiteBuilder()
        {
            suite = new Suite();
        }

        public SuiteBuilder SetSuiteName(string name)
        {
            suite.Name = name;
            return this;
        }

        public SuiteBuilder SetSuiteDescription(string description)
        {
            suite.Description = description;
            return this;
        }

        public SuiteBuilder SetSuitePreconditions(string preconditions)
        {
            suite.Preconditions = preconditions;
            return this;
        }

        public Suite Build()
        {
            return suite;
        }
    }
}
