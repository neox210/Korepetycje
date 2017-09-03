using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Korepetycje.Models
{
    public class SchoolList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Exercises> Exercise { get; set; }
    }
}