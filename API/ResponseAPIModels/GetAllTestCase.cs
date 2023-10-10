using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ResponseAPIModels
{
        public class GetAllTestCase
        {
            public bool Status { get; set; }
            public ListCaseResult Result { get; set; }
        }

        public class ListCaseResult
        {           
            public List<CaseResult> entities { get; set; }
        }    
}
