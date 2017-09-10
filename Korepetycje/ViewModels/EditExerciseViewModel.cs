using Korepetycje.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.ViewModels
{
    public class EditExerciseViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public int SchoolListId { get; set; }
        [Required]
        public int SchoolClassListId { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Content { get; set; }
 
        public string FotoPath { get; set; }

        public IEnumerable<Sections> Section { get; set; }
        public IEnumerable<SchoolClassList> SchoolClassList { get; set; }
        public IEnumerable<SchoolList> SchoolList { get; set; }
    }
}