using Korepetycje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class SubjectController : Controller
    {
        private ApplicationDbContext context;

        public SubjectController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var ListOfSubjects = context.Subjects.ToList();

            return View("Index", "_AdminLayout", ListOfSubjects);
        }

        public ActionResult Create()
        {
            return View("Create", "_AdminLayout");
        }

        [HttpPost]
        public ActionResult Create(Subjects subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}