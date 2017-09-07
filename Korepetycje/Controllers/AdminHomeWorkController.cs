using Korepetycje.Models;
using Korepetycje.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class AdminHomeWorkController : Controller
    {
        private ApplicationDbContext context;

        public AdminHomeWorkController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var ListOfHomeworks = context.Homeworks.ToList();
            List<IndexAdminHomeworkViewModel> models = new List<IndexAdminHomeworkViewModel>();
            var model = new IndexAdminHomeworkViewModel();
         
            foreach (var item in ListOfHomeworks)
            {
                item.Student = context.Users.SingleOrDefault(s => s.Id == item.StudentId);
                item.Exercise = context.Excercises.SingleOrDefault(e => e.Id == item.ExerciseId);
                item.Exercise.Section = context.Sections.SingleOrDefault(s => s.Id == item.Exercise.SectionId);
            }

            return View("Index", ListOfHomeworks);
        }

        public ActionResult Create(string query = null)
        {
            var viewModel = new CreateHomeworkViewModel()
            {
                Student = context.Users.ToList(),
                Exercise = context.Excercises.ToList(),
                SearchTerm = query
                
            };

            foreach (var item in viewModel.Exercise)
            {
                item.SchoolClassList = context.SchoolClassList.SingleOrDefault(s => s.Id == item.SchoolClassListId);
                item.SchoolList = context.SchoolList.SingleOrDefault(s => s.Id == item.SchoolListId);
                item.Section= context.Sections.SingleOrDefault(s => s.Id == item.SectionId);
            }

            if (!string.IsNullOrWhiteSpace(query))
            {
                viewModel.Exercise = viewModel.Exercise.Where(t => t.Topic.ToLower().Contains(query.ToLower()) 
                                                        || t.Section.Name.ToLower().Contains(query.ToLower()) 
                                                        || t.SchoolList.Name.ToLower().Contains(query.ToLower()));

            }

            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult Search(CreateHomeworkViewModel viewModel)
        {
            return RedirectToAction("Create", "AdminHomeWork", new { query = viewModel.SearchTerm });
        }
    }
}