using System;
using System.Collections.Generic;
using System.Text;

namespace OnionMessenger.Domains
{
    class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
