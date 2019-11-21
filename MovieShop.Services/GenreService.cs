using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data.Repositories;
using MovieShop.Entities;

namespace MovieShop.Services
{
   public class GenreService: IGenreService
   {
       private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll();
        }
    }

   public interface IGenreService
   {
       IEnumerable<Genre> GetAllGenres();
   }
}
