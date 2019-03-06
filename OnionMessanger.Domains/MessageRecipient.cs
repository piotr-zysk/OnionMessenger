using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnionMessenger.Domains
{
    public class MessageRecipient
    {
        [Key, Column(Order=0)]
        public int UserId { get; set; }
        public User User { get; set; }
        [Key, Column(Order = 1)]
        public int MessageId { get; set; }
        public Message Message { get; set; }
        [Required]
        public byte Status { get; set; }
    }
}
