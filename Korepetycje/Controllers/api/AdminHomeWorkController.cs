using Korepetycje.Dto;
using Korepetycje.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Korepetycje.Controllers.Api
{
    [Authorize]
    public class AdminHomeWorkController : ApiController
    {
        private ApplicationDbContext context;
        public AdminHomeWorkController()
        {
            context = new ApplicationDbContext();

        }
        [HttpPost]
        public IHttpActionResult AddHomework(AdminHomeWrokDto dto)
        {
            if (context.Homeworks.Any( e => e.ExerciseId == dto.ExerciseId && e.StudentId == dto.StudentId))
            {
                return BadRequest("To zadanie juz jest przydzielone do tego ucznia!");
            }
            var homework = new Homeworks()
            {
                StudentId = dto.StudentId,
                ExerciseId = dto.ExerciseId,
                TaskDateTime = DateTime.Now.ToString("HH:mm d MMMMM yyyy"),
                IsRead = false
            };
            context.Homeworks.Add(homework);
            context.SaveChanges();

            return Ok();
        }
    }
}
