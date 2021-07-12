using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.AdminInfo.Model
{
    public class LoginResponse
    {
        public string AdminId { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
        public string EmailId { get; set; }
        public string message { get; set; }
    }
}
