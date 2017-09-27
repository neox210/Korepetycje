using Korepetycje.Models;
using System.Linq;
using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class AdminCalendarController : Controller
    {
        private ApplicationDbContext context;

        public AdminCalendarController()
        {
            context = new ApplicationDbContext();
        }
        // GET: AdminCalendar
        public ActionResult Index()
        {
            var students = context.Users.Where(s => s.Visible == true).ToList();

            return View(students);
        }
    }
}