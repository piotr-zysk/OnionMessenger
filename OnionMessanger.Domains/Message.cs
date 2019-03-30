using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionMessenger.Domains
{
    public class Message : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        // [SqlDefaultValue(DefaultValue = "getutcdate()")]
        // zaimplementuj custom attribute for default
        // https://stackoverflow.com/questions/19554050/entity-framework-6-code-first-default-value
        public DateTime TimeCreated { get; set; }
        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; }
        public User User { get; set; }
        [Required]
        public byte Priority { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
