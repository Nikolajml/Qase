using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Qase.Models
{
    public class Suite
    {
        [JsonPropertyName("title")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("preconditions")] public string Preconditions { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }
    }
}
