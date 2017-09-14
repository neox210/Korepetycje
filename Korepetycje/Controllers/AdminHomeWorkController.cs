using Korepetycje.Models;
using Korepetycje.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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

        public ActionResult Open(int id)
        {
            var homework = context.Homeworks.SingleOrDefault(h => h.Id == id);
            var exercise = context.Excercises.SingleOrDefault(e => e.Id == homework.ExerciseId);
            var messages = context.HomeworkChatMessages.Where(m => m.HomeworkId == homework.Id).OrderBy(m => m.Date).ToList();
            var userId = User.Identity.GetUserId();

            foreach (var message in messages)
            {
                message.Student = context.Users.SingleOrDefault(u => u.Id == message.StudentId);
            }

            var viewModel = new OpenHomeWorkViewModel()
            {
                Exercise = exercise,
                Messages = messages,
                HomeWorkId = homework.Id,
                LoggedUserId = userId
                
            };

            

            return View("Open", viewModel);
        }

        [HttpPost]
        public ActionResult AddMessage(OpenHomeWorkViewModel model)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase Foto = Request.Files[0];

                if (Foto != null && Foto.ContentLength > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(Foto.FileName);
                    var fileExtension = Path.GetExtension(Foto.FileName);
                    fileName = fileName + DateTime.Now.ToString("fff-dd-MM-yyyy") + fileExtension;
                    model.NewMessageFotoPath= "~/HomeworkFotos/MessagesFotos/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/HomeworkFotos/MessagesFotos"), fileName);
                    Foto.SaveAs(fileName);
                }
            }

            var message = new HomeworkChatMessages()
            {
                HomeworkId = model.HomeWorkId,
                StudentId = User.Identity.GetUserId(),
                Content = model.NewMessageConntent,
                FotoPath = model.NewMessageFotoPath,
                Date = DateTime.Now
            };
            context.HomeworkChatMessages.Add(message);
            context.SaveChanges();

            return RedirectToAction ("Open", new { id = model.HomeWorkId});
        }
        
    }
}