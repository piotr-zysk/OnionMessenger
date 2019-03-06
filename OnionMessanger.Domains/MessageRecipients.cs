using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnionMessenger.Domains
{
    class MessageRecipients
    {
        [Key, Column(Order=0)]
        public User Recipient { get; set; }
        [Key, Column(Order = 1)]
        public Message Message { get; set; }
        [Required]
        public byte Status { get; set; }
    }
}
