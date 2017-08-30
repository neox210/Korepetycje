using Korepetycje.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.ViewModels
{
    public class CreateExerciseViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public decimal Result { get; set; }

        public string FotoPath { get; set; }

        public IEnumerable<Subjects> Subject { get; set; }
        public IEnumerable<Sections> Section { get; set; }
    }
}