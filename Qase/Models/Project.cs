using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Models
{
    public class Project
    {
        [JsonProperty("title")] public string Title { get; set; }        
        [JsonProperty("code")] public string Code { get; set; }       
    }
}
