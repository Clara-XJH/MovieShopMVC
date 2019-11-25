using System.Web.Mvc;
using MovieShop.Services;

namespace MovieShopMVC.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Route("genre/{genreId}")]
        // GET: Movies
        public ActionResult Genre(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId);
            return View("Index", movies);
        }
    }
}