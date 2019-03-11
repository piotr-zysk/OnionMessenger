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
        [Required(ErrorMessage ="Login cannot be empty")]
        [MinLength(4,ErrorMessage ="Login must be at least 4 character long")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Range(10, 100, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public byte Age { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
