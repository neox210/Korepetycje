using Korepetycje.Models;
using System.Linq;
using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class SectionController : Controller
    {

        private ApplicationDbContext context;

        public SectionController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var ListOfSectiones = context.Sections.ToList();
            return View("Index", "_AdminLayout", ListOfSectiones);
        }

        public ActionResult Create()
        {
            return View("Create", "_AdminLayout");
        }

        [HttpPost]
        public ActionResult Create(Sections section)
        {
            context.Sections.Add(section);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}