using Korepetycje.Dto;
using Korepetycje.Models;
using System.Linq;
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
        public IHttpActionResult Create(SectionCreateApiDto model)
        {
            var section = new Sections()
            {
                Name = model.Name
            };
            context.Sections.Add(section);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var section = context.Sections.SingleOrDefault(s => s.Id == id);
            section.Delete();
            context.SaveChanges();
            return Ok();
        }

        [HttpPatch]
        public IHttpActionResult Edit(SectionEditApiDto model)
        {
            var section = context.Sections.SingleOrDefault(s => s.Id == model.Id);
            section.Name = model.Name;
            context.SaveChanges();

            return Ok();
        }
    }
}
