using Qase.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qase.Models
{
    public record User
    {
        public UserType UserType { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
