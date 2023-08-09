using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class DefectBuilder
    {
        private Defect defect;

        public DefectBuilder()
        {
            defect = new Defect();
        }

        public DefectBuilder SetDefectTitle(string defectTitle)
        {
            defect.DefectTitle = defectTitle;
            return this;
        }

        public DefectBuilder SetActualResult(string actualResult)
        {
            defect.ActualResult = actualResult;
            return this;
        }

        public Defect Build()
        {
            return defect;
        }
    }
}
