using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class Plan
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }  
        [JsonPropertyName("cases")] public List<Case> Cases { get; set; }
    }
}
