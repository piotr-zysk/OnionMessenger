using System;
using System.ComponentModel.DataAnnotations;

namespace OnionMessenger.Domains
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
