using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class Case
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("suite_id")] public string Id { get; set; }
    }
}
