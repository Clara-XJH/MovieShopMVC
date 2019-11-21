using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data.Repositories;
using MovieShop.Entities;

namespace MovieShop.Services
{
   public class MovieService: IMovieService
   {
       private readonly IMovieRepository _movieRepository;
       public MovieService(IMovieRepository movieRepository)
       {
           _movieRepository = movieRepository;
       }
        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            return _movieRepository.GetTopGrossingMovies();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }
   }

  public interface IMovieService
  {
      IEnumerable<Movie> GetTopGrossingMovies();
      IEnumerable<Movie> GetMoviesByGenre(int genreId);
  }
}
