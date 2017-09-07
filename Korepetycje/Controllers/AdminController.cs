using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}