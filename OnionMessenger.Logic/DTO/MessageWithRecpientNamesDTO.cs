using System;
using System.Collections.Generic;

namespace OnionMessenger.Logic.DTO
{
    public class MessageWithRecpientNamesDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime TimeCreated { get; set; }

        public int AuthorId { get; set; }

        public byte Priority { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<UserDTO> Recipients { get; set; }
    }
}
