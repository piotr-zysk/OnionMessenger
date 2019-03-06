using System;
using System.ComponentModel.DataAnnotations;


namespace OnionMessenger.Domains
{
    class Message : BaseModel
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
        public int UserId { get; set; }
        public User Author { get; set; }
        public byte Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
