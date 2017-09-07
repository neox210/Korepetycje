using Korepetycje.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class StudentHomeWorkNotificationController : ApiController
    {
        private ApplicationDbContext context;

        public StudentHomeWorkNotificationController()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<Homeworks> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var homeworks = context.Homeworks.Where(h => h.StudentId == userId && h.IsRead == false).ToList();

            return homeworks;
        }
    }
}
