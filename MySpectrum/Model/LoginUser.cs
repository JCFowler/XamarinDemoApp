using System;
using System.Collections.Generic;

namespace MySpectrum.Model
{
    public class LoginUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<User> Users { get; set; }
    }
}
