using Korepetycje.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class AdminEventsController : ApiController
    {
        private ApplicationDbContext context;

        public AdminEventsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<CallendarEvents> GetEvents()
        {
            var events = context.CallendarEvents.ToList();
            return events;
        }

        [HttpPost]
        public IHttpActionResult SaveEvent(CallendarEvents e)
        {
            if (e.Id > 0)
            {
                var calendarEvent = context.CallendarEvents.FirstOrDefault(ce => ce.Id == e.Id);

                calendarEvent.Subject = e.Subject;
                calendarEvent.Description = e.Description;
                calendarEvent.Start = e.Start;
                calendarEvent.End = e.End;
                calendarEvent.IsFullDay = e.IsFullDay;
                calendarEvent.ThemeColor = e.ThemeColor;
            }

            else
            {
                context.CallendarEvents.Add(e);
            }

            context.SaveChanges();

            return Ok();
        }
    }
}
