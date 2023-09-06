using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ResponseAPIModels
{    
    public class GetAllTestDefect
    {
        public bool Status { get; set; }
        public ListDefectResult Result { get; set; }
    }

    public class ListDefectResult
    {
        public List<DefectResult> entities { get; set; }
    }
}
