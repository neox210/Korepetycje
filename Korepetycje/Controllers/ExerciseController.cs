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

            return View("Index", "_AdminLayout", ListOfExercises);
        }

        public ActionResult Create()
        {
            var model = new CreateExerciseViewModel()
            {
                Section = context.Sections.ToList(),
                Subject = context.Subjects.ToList()
            };
            return View("Create", "_AdminLayout", model);
        }

        [HttpPost]
        public ActionResult Create(CreateExerciseViewModel exercise)
        {

            if (Request.Files.Count>0)
            {
                HttpPostedFileBase Foto = Request.Files[0];
                var fileName = Path.GetFileNameWithoutExtension(Foto.FileName);
                var fileExtension = Path.GetExtension(Foto.FileName);
                fileName = fileName + DateTime.Now.ToString("fff-dd-MM-yyyy") + fileExtension;
                exercise.FotoPath = "~/HomeworkFotos/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/HomeworkFotos/"), fileName);
                Foto.SaveAs(fileName);
            }

            var newExercise = new Exercises()
            {
                SubjectId = exercise.SubjectId,
                SectionId = exercise.SectionId,
                Topic = exercise.Topic,
                Content = exercise.Content,
                Result = exercise.Result,
                FotoPath = exercise.FotoPath
            };

            context.Excercises.Add(newExercise);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}