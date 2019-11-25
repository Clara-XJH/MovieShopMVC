using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Services;

namespace MovieShopMVC.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        // GET: Genres
        public PartialViewResult Index()
        {
            return PartialView("GenresView", _genreService.GetAllGenres());
        }
    }
}