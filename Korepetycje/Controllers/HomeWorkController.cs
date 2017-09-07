using Korepetycje.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class HomeWorkController : Controller
    {
        private ApplicationDbContext context;

        public HomeWorkController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var homeworks = context.Homeworks.ToList().Where(e => e.StudentId == User.Identity.GetUserId());
            foreach (var homework in homeworks)
            {
                homework.Exercise = context.Excercises.SingleOrDefault(e => e.Id == homework.ExerciseId);
                homework.Exercise.Section = context.Sections.SingleOrDefault(e => e.Id == homework.Exercise.SectionId);
            }

            return View("Index", homeworks);
        }

        public ActionResult Open(int id)
        {

            Exercises exercise = context.Excercises.SingleOrDefault(e => e.Id == id);
            exercise.Section = context.Sections.SingleOrDefault(s => s.Id == exercise.SectionId);

            var userid = User.Identity.GetUserId();
            var homework = context.Homeworks.SingleOrDefault(h => h.StudentId == userid && h.ExerciseId == id);
            homework.IsRead = true;

            var notification = new Notifications()
            {
                StudentId = userid,
                FullName = context.Users.SingleOrDefault( s=> s.Id == userid).FullName,
                Content = "przeczytał(a) zadanie domowe " + exercise.Topic,
                IsRead = false,
                NotificationDate = DateTime.Now.ToString("HH:mm d MMMMM yyyy")

            };

            context.Notifications.Add(notification);
            context.SaveChanges();
            return View("Open", exercise);
        }
    }
}