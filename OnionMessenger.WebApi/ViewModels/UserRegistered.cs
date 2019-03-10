﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionMessenger.WebApi.ViewModels
{
    public class UserRegistered
    {
        public string  Title { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Login { get; set; }
    }
}