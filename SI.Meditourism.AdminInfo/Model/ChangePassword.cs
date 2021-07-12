using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.AdminInfo.Model
{
    public class ChangePassword
    {
        public string passwordHash { get; set; }
        public string oldPassword { get; set; }
        public string email { get; set; }
    }
}
