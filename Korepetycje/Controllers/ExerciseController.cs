using Korepetycje.Models;
using Korepetycje.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class ExerciseController : Controller
    {

        private ApplicationDbContext context;

        public ExerciseController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var ListOfExercises = context.Excercises.ToList();
            foreach (var exercise in ListOfExercises)
            {
                exercise.Section = context.Sections.SingleOrDefault(s => s.Id == exercise.SectionId);
                exercise.SchoolList = context.SchoolList.SingleOrDefault(s => s.Id == exercise.SchoolListId);
                exercise.SchoolClassList = context.SchoolClassList.SingleOrDefault(s => s.Id == exercise.SchoolClassListId);
            }

            return View("Index", "_AdminLayout", ListOfExercises);
        }

        public ActionResult Create()
        {
            var model = new CreateExerciseViewModel()
            {
                Section = context.Sections.ToList(),
                SchoolList = context.SchoolList.ToList(),
                SchoolClassList = context.SchoolClassList.ToList()
        
            };
            return View("Create", "_AdminLayout", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CreateExerciseViewModel exercise)
        {
            if (!ModelState.IsValid)
            {
                var model = new CreateExerciseViewModel()
                {
                    Section = context.Sections.ToList(),
                    SchoolList = context.SchoolList.ToList(),
                    SchoolClassList = context.SchoolClassList.ToList()

                };
                return View("Create", "_AdminLayout", model);
            }

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase Foto = Request.Files[0];

                if (Foto != null && Foto.ContentLength > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(Foto.FileName);
                    var fileExtension = Path.GetExtension(Foto.FileName);
                    fileName = fileName + DateTime.Now.ToString("fff-dd-MM-yyyy") + fileExtension;
                    exercise.FotoPath = "~/HomeworkFotos/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/HomeworkFotos/"), fileName);
                    Foto.SaveAs(fileName);
                }
            }

            var newExercise = new Exercises()
            {
                SectionId = exercise.SectionId,
                SchoolListId = exercise.SchoolListId,
                SchoolClassListId = exercise.SchoolClassListId,
                Topic = exercise.Topic,
                Content = exercise.Content,
                FotoPath = exercise.FotoPath
            };

            context.Excercises.Add(newExercise);
            context.SaveChanges();

            return RedirectToAction ("Index", "Exercise");
        }
    }
}