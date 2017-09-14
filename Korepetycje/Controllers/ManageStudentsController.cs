using Korepetycje.Models;
using Korepetycje.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Korepetycje.Controllers
{
    public class ManageStudentsController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public ManageStudentsController()
        {
            context = new ApplicationDbContext();
        }

        // GET: ManageStudents
        public ActionResult Index()
        {
            
            var usersWithRoles = (from user in context.Users
                                  from userRole in user.Roles
                                  join role in context.Roles on userRole.RoleId equals
                                  role.Id
                                  select new ManageStudentsViewModel()
                                  {
                                      Student = user,
                                      RoleName = role.Name
                                  }).ToList();
            var allStudents = context.Users.ToList();

            foreach (var student in allStudents)
            {
                if (!(usersWithRoles.Any(s => s.Student == student)))
                {
                    var newStudent = new ManageStudentsViewModel()
                    {
                        Student = student,
                    };
                    usersWithRoles.Add(newStudent);
                }
            }

            return View("Index", usersWithRoles);
        }

    }
}