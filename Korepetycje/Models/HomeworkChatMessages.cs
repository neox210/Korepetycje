using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class HomeworkChatMessages
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public int HomeworkId { get; set; }
        [Required]
        public string Content { get; set; }

        public string FotoPath { get; set; }

        public ApplicationUser Student { get; set; }
        public Homeworks Homework { get; set; } 
    }
}