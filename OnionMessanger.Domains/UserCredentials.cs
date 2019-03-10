using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnionMessenger.Domains
{
    public class UserCredentials
    {        
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
