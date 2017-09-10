using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class Homeworks
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

        public bool IsDeleted { get; private set; }

        public ApplicationUser Student { get; set; }
        public Exercises Exercise { get; set; }
        public ICollection<HomeworkChatMessages> HomeworkChatMessages { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}