using Korepetycje.Dto;
using Korepetycje.Models;
using System.Linq;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class AdminNotificationsController : ApiController
    {
        private ApplicationDbContext contex;

        public AdminNotificationsController()
        {
            contex = new ApplicationDbContext();
        }

        public AdminNotificationsDto GetNotifications()
        {
            var newNotifications = contex.Notifications.Where(n => n.IsRead == false).ToList();
            var oldNotifications = contex.Notifications.OrderBy(d => d.NotificationDate).Take(5).ToList();

            var notifications = new AdminNotificationsDto()
            {
                OldNotifications = oldNotifications,
                NewNotifications = newNotifications
            };
            return notifications;
        }

        [HttpPost]
        public IHttpActionResult ReadUpdate()
        {
            var notifications = contex.Notifications.Where(n => n.IsRead == false).ToList();
            foreach (var item in notifications)
            {
                item.IsRead = true;
            }
            contex.SaveChanges();

            return Ok();
        }
    }
}
