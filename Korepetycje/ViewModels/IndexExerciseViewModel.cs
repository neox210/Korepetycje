using Korepetycje.Models;
using System.Collections.Generic;

namespace Korepetycje.ViewModels
{
    public class IndexExerciseViewModel
    {
        public IEnumerable<Exercises> Exercises { get; set; }
        public IEnumerable<Sections> Sections{ get; set; }
    }
}