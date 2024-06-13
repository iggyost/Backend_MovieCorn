using Backend_MovieCorn.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MovieCorn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        public static MovieCornDbContext context = new MovieCornDbContext();
        [HttpGet]
        [Route("get/{tagName}")]
        public ActionResult<IEnumerable<Tag>> GetOne(string tagName)
        {
            var selectedTag = context.Tags.Where(x => x.Name.Contains(tagName)).FirstOrDefault();
            if (selectedTag != null)
            {
                return Ok(selectedTag);
            }
            return NotFound();
        }
    }
}
