using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnionMessenger.Domains
{
    public class User : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
