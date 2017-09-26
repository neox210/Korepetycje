using System;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class CallendarEvents
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}