using Backend_MovieCorn.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend_MovieCorn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesViewController : Controller
    {
        public static MovieCornDbContext context = new MovieCornDbContext();
        [HttpPost]
        [Route("get")]
        public ActionResult<IEnumerable<MoviesView>> Get([FromBody] List<Tag> tagList)
        {
            List<MoviesView> moviesList = new List<MoviesView>();
            if (tagList.Count > 1)
            {
                foreach (var movie in context.MoviesViews.ToList())
                {
                    foreach (var tag in tagList)
                    {
                        if (movie.TagId == tag.TagId)
                        {
                            moviesList.Add(movie);
                        }
                    }
                }

                var sortedMoviesList = moviesList.DistinctBy(x => x.Name).ToList();
                
                return Ok(sortedMoviesList);
            }
            else if (tagList.Count == 1)
            {
                var selectedTag = tagList.FirstOrDefault();
                moviesList.AddRange(context.MoviesViews.Where(x => x.TagId == selectedTag.TagId).ToList());
                return Ok(moviesList);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("get/popular")]
        public ActionResult<IEnumerable<MoviesView>> GetPopular()
        {
            var moviesList = context.MoviesViews.ToList();
            var recordCount = 10;
            var entityList = moviesList.OrderBy(t => Guid.NewGuid()).Take(recordCount).DistinctBy(x => x.Name);
            return entityList.ToList();
        }
        [HttpGet]
        [Route("get/recomend")]
        public ActionResult<IEnumerable<MoviesView>> GetRecomend()
        {
            var moviesList = context.MoviesViews.ToList();
            var recordCount = 4;
            var entityList = moviesList.OrderBy(t => Guid.NewGuid()).Take(recordCount).DistinctBy(x => x.Name);
            return entityList.ToList();
        }
        [HttpGet]
        [Route("select/{movieId}")]
        public ActionResult<IEnumerable<MoviesView>> Select(int movieId)
        {
            var selectedMovie = context.MoviesViews.Where(x => x.MovieId == movieId).FirstOrDefault();
            return Ok(selectedMovie);
        }
    }
}
