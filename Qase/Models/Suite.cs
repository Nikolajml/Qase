using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class Suite
    {
        [JsonProperty("title")] public string Name { get; set; }
        public string Description { get; set; }
        public string Preconditions { get; set; }
        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

    }
}
