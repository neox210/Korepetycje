using Korepetycje.Dto;
using Korepetycje.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class RoleController : ApiController
    {
        private ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult AddRole(RoleDto model)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            manager.AddToRole(model.StudentId, model.RoleName);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteRole(RoleDto model)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            manager.RemoveFromRole(model.StudentId, model.RoleName);
            return Ok();
        }
    }
}
