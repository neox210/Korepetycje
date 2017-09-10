using Korepetycje.Dto;
using Korepetycje.Models;
using System.Linq;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class ExerciseController : ApiController
    {
        private ApplicationDbContext context;

        public ExerciseController()
        {
            context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var exercise = context.Excercises.SingleOrDefault(e => e.Id == id);
            exercise.Delete();
            context.SaveChanges();

            return Ok();
        }

        [HttpPatch]
        public IHttpActionResult UpdateSection(ExerciseEditSectionDto model)
        {
            var exercise = context.Excercises.SingleOrDefault(e => e.Id == model.ExerciseId);
            exercise.SectionId = model.SectionId;
            context.SaveChanges();

            return Ok();
        }
    }
}
