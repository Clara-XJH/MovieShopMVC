using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;

namespace MovieShop.Data.Repositories
{
   public class MovieRepository: Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            return _context.Movies.OrderByDescending(m => m.Revenue).Include(m => m.Genres).Take(20).ToList();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _context.Genres.Where(g => g.Id == genreId).SelectMany(m => m.Movies).ToList();
        }
    }

   public interface IMovieRepository : IRepository<Movie>
   {
       IEnumerable<Movie> GetTopGrossingMovies();
       IEnumerable<Movie> GetMoviesByGenre(int genreId);
   }
}
