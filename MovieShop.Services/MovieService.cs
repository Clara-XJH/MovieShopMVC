using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data.Repositories;
using MovieShop.Entities;
using MovieShop.Entities.Common;

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

        public PaginatedList<Movie> GetMoviesByPagination(int pageIndex, string filter = null, int pageSize = 20)
        {
            Expression<Func<Movie, bool>> filterExpression = null;
            if (!string.IsNullOrEmpty(filter))
            {
                filterExpression = movie => filter != null && movie.Title.Contains(filter);
            }
            return _movieRepository.GetPagedData(pageIndex, pageSize, movies => movies.OrderBy(m => m.Title),
                                                filterExpression);
        }
   }

  public interface IMovieService
  {
      IEnumerable<Movie> GetTopGrossingMovies();
      IEnumerable<Movie> GetMoviesByGenre(int genreId);
      PaginatedList<Movie> GetMoviesByPagination(int pageIndex, string filter, int pageSize = 20);
  }
}
