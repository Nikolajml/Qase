using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class RunBuilder
    {
        private Run run;

        public RunBuilder()
        {
            run = new Run();
        }                

        public RunBuilder SetRunDescription(string description)
        {
            run.Description = description;
            return this;
        }

        public RunBuilder SetCode(string code)
        {
            run.Code = code;
            return this;
        }

        public RunBuilder SetCases(List<int> cases)
        {
            run.Cases = cases;
            return this;
        }

        public Run Build()
        {
            return run;
        }
    }
}
