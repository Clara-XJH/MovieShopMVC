using System.Linq;
using System.Web.Mvc;
using MovieShop.Entities;
using MovieShop.Services;
using X.PagedList;

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
        public ActionResult Genre(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m => m.Title).ToList();
            return View("Index", movies);
        }

        [Route("")]
        public ActionResult GetMovies(string filter= null, int pageIndex = 1, int pageSize = 20)
        {
            var movies = _movieService.GetMoviesByPagination(pageIndex, filter, pageSize);
            var pagedMovies = new StaticPagedList<Movie>(movies, pageIndex, pageSize, movies.TotalCount);
            return View("Index", pagedMovies);
        }



        [Route("create")]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Movie movie)
        {

            return View("Index");
        }
    }
}