using OnionMessenger.Domains;
using System;
using System.Collections.Generic;

namespace OnionMessenger.Logic.DTO
{
    public class MessageDTO
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime TimeCreated { get; set; }

        public int AuthorId { get; set; }

        public byte Priority { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<int> Recipients { get; set; }
    }
}
