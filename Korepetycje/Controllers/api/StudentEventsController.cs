using Korepetycje.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class StudentEventsController : ApiController
    {
        private ApplicationDbContext context;

        public StudentEventsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<CallendarEvents> GetEvents()
        {
            var userId = User.Identity.GetUserId();
            var events = context.CallendarEvents.Where(e => e.StudentId == userId).ToList();
            return events;
        }
    }
}
