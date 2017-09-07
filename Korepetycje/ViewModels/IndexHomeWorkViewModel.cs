using Korepetycje.Models;
using System.Collections.Generic;

namespace Korepetycje.ViewModels
{
    public class IndexHomeWorkViewModel
    {
        public IEnumerable<Homeworks> Homeworks { get; set; }
        public int SelectedId { get; set; }
    }
}