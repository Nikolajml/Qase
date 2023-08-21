﻿using BusinessObject.Models.Enum;

namespace BusinessObject.Models
{
    public record User
    {
        public UserType UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
