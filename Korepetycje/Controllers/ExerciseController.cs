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
            var indexModel = new IndexExerciseViewModel()
            {
                Exercises = context.Excercises.Where(e => e.IsDeleted == false).ToList(),
                Sections = context.Sections.Where(s => s.IsDeleted == false).ToList()
            };

            foreach (var exercise in indexModel.Exercises)
            {
                exercise.Section = context.Sections.SingleOrDefault(s => s.Id == exercise.SectionId);
                exercise.SchoolList = context.SchoolList.SingleOrDefault(s => s.Id == exercise.SchoolListId);
                exercise.SchoolClassList = context.SchoolClassList.SingleOrDefault(s => s.Id == exercise.SchoolClassListId);
            }

            return View("Index", indexModel);
        }

        public ActionResult Create()
        {
            var model = new CreateExerciseViewModel()
            {
                Section = context.Sections.ToList(),
                SchoolList = context.SchoolList.ToList(),
                SchoolClassList = context.SchoolClassList.ToList()
        
            };
            return View("Create", model);
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
                return View("Create", model);
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

        public ActionResult Edit(int id)
        {
            var model = new CreateExerciseViewModel()
            {
                Id = id,
                SchoolListId = context.Excercises.SingleOrDefault(e => e.Id == id).SchoolListId,
                SchoolClassListId = context.Excercises.SingleOrDefault(e => e.Id == id).SchoolClassListId,
                SectionId = context.Excercises.SingleOrDefault(e => e.Id == id).SectionId,
                Topic = context.Excercises.SingleOrDefault(e => e.Id == id).Topic,
                Content = context.Excercises.SingleOrDefault(e => e.Id == id).Content,
                FotoPath= context.Excercises.SingleOrDefault(e => e.Id == id).FotoPath,


                Section = context.Sections.ToList(),
                SchoolList = context.SchoolList.ToList(),
                SchoolClassList = context.SchoolClassList.ToList()
            };

        return View("Create", model);
        }
    }

    
}