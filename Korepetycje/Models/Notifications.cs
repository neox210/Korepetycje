using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class Notifications
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string NotificationDate { get; set; }
        [Required]
        public bool IsRead { get; set; }
        


        public ApplicationUser Student { get; set; }

    }
}