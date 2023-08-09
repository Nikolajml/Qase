using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class CaseBuilder
    {
        private Case Case;
        
        public CaseBuilder()
        {
            Case = new Case();
        }

        public CaseBuilder SetCaseTitle(string title)
        {
            Case.Title = title;
            return this;
        }

        public CaseBuilder SetDescription(string description)
        {
            Case.Description = description;
            return this;
        }

        public Case Build()
        {
            return Case;
        }
    }
}
