using Korepetycje.Models;
using System.Collections.Generic;

namespace Korepetycje.Dto
{
    public class AdminNotificationsDto
    {
        public IEnumerable<Notifications> NewNotifications { get; set; }
        public IEnumerable<Notifications> OldNotifications { get; set; }
    }
}