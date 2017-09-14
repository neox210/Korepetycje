﻿using Korepetycje.Models;
using Korepetycje.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Web;
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
            var userid = User.Identity.GetUserId();
            var homeworkUserId = context.Homeworks.SingleOrDefault(h => h.Id == id).StudentId;
            if (userid != homeworkUserId)
            {
                return RedirectToAction("Index");
            }

            var homework = context.Homeworks.SingleOrDefault(h => h.Id == id);
            var exercise = context.Excercises.SingleOrDefault(e => e.Id == homework.ExerciseId);
            exercise.Section = context.Sections.SingleOrDefault(s => s.Id == exercise.SectionId);
            var messages = context.HomeworkChatMessages.Where(m => m.HomeworkId == homework.Id).OrderBy(m => m.Date).ToList();
            

            foreach (var message in messages)
            {
                message.Student = context.Users.SingleOrDefault(u => u.Id == message.StudentId);
            }

            var viewModel = new OpenHomeWorkViewModel()
            {
                Exercise = exercise,
                Messages = messages,
                HomeWorkId = homework.Id,
                LoggedUserId = userid

            };

            if (!homework.IsRead)
            {
                homework.IsRead = true;

                var notification = new Notifications()
                {
                    StudentId = userid,
                    FullName = context.Users.SingleOrDefault(s => s.Id == userid).FullName,
                    Content = "przeczytał(a) zadanie domowe " + exercise.Topic,
                    IsRead = false,
                    NotificationDate = DateTime.Now.ToString("HH:mm d MMMMM yyyy")

                };
                context.Notifications.Add(notification);
                context.SaveChanges();
            }
            
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
                    model.NewMessageFotoPath = "~/HomeworkFotos/MessagesFotos/" + fileName;
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

            return RedirectToAction("Open", new { id = model.HomeWorkId });
        }
    }
}