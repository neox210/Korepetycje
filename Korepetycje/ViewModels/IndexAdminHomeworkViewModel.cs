using Korepetycje.Models;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.ViewModels
{
    public class IndexAdminHomeworkViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        [Required]
        public string TaskDateTime { get; set; }
        [Required]
        public bool IsRead { get; set; }

        public ApplicationUser Student { get; set; }
        public Exercises Exercise { get; set; }
    }
}