using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.ResponseAPIModels
{  
    public class ProjectResult
    {
        public string code { get; set; }
    }

    public class ProjectApiModel
    {
        public bool status { get; set; }
        public ProjectResult result { get; set; }
    }
}
