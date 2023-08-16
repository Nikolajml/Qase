using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class Defect
    {
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("title")] public string DefectTitle { get; set; }
        [JsonPropertyName("actual_result")] public string ActualResult { get; set; }
        [JsonPropertyName("severity")] public int Severity { get; set; }

        
    }
}
