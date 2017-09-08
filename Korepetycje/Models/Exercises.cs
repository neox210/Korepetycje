using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class Exercises
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

        public string Content { get; set; }
        
        public string FotoPath { get; set; }

        public bool IsDeleted { get; private set; }

        public Sections Section { get; set; }
        public SchoolClassList SchoolClassList { get; set; }
        public SchoolList SchoolList { get; set; }
        public ICollection<Homeworks> Homeworks { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}