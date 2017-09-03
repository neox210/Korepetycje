using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class SchoolClassList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClassNumber { get; set; }

        public ICollection<Exercises> Exercise { get; set; }
    }
}