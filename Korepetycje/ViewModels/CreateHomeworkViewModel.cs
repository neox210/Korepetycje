using Korepetycje.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.ViewModels
{
    public class CreateHomeworkViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public string SearchTerm { get; set; }

        public IEnumerable<ApplicationUser> Student { get; set; }
        public IEnumerable<Exercises> Exercise { get; set; }
    }
}