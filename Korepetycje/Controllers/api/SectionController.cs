using Korepetycje.Dto;
using Korepetycje.Models;
using System.Web.Http;

namespace Korepetycje.Controllers.api
{
    public class SectionController : ApiController
    {
        private ApplicationDbContext context;
        public SectionController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(SectionApiDto model)
        {
            var section = new Sections()
            {
                Name = model.Name
            };
            context.Sections.Add(section);
            context.SaveChanges();

            return Ok();
        }
    }
}
