using Backend_MovieCorn.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MovieCorn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesViewController : Controller
    {
        public static MovieCornDbContext context = new MovieCornDbContext();
        [HttpGet]
        [Route("get/{userId}")]
        public ActionResult<IEnumerable<FavoritesView>> Get(int userId)
        {
            var favorites = context.FavoritesViews.Where(x => x.UserId == userId).ToList();
            if (favorites != null)
            {
                return favorites;
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("set/{userId}/{movieId}")]
        public ActionResult<IEnumerable<FavoritesView>> Set(int userId, int movieId)
        {
            Favorite favorite = new Favorite()
            {
                UserId = userId,
                MovieId = movieId
            };
            context.Favorites.Add(favorite);
            context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("remove/{userId}/{movieId}")]
        public ActionResult<IEnumerable<FavoritesView>> Remove(int userId, int movieId)
        {
            var selectedFavorite = context.Favorites.Where(x => x.UserId == userId && x.MovieId == movieId).FirstOrDefault();
            if (selectedFavorite != null)
            {
                context.Favorites.Remove(selectedFavorite);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}