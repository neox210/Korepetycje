using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class Exercises
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SubjectId { get; set;}
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public decimal Result { get; set; }
        public string FotoPath { get; set; }

        public Subjects Subject { get; set; }
        public Sections Section { get; set; }
    }
}