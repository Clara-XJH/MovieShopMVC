using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;

namespace MovieShop.Data.Repositories
{
   public class MovieRepository: Repository<Movie>, IMovieRepository
    {
        protected MovieRepository(MovieShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            return _context.Movies.OrderBy(m => m.Revenue).Take(20).ToList();
        }
    }

   public interface IMovieRepository : IRepository<Movie>
   {
       IEnumerable<Movie> GetTopGrossingMovies();
   }
}
