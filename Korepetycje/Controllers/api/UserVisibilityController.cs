using Korepetycje.Models;
using System.Linq;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class UserVisibilityController : ApiController
    {
        public ApplicationDbContext context { get; set; }

        public UserVisibilityController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult VisibleTrue(string id)
        {
            var student = context.Users.SingleOrDefault(u => u.Id == id);
            student.Visible = true;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult VisibleFalse(string id)
        {
            var student = context.Users.SingleOrDefault(u => u.Id == id);
            student.Visible = false;
            context.SaveChanges();

            return Ok();
        }
    }
}
