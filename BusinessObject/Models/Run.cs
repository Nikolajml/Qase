using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UI.Models
{
    public class Run
    {       
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("cases")] public List<int> Cases { get; set; }

        public new string ToString()
        {
            return $"Description: {Description}";
        }
    }
}
