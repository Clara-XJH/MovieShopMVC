using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieShop.Data.Repositories;
using MovieShop.Entities;
using MovieShop.Services;

namespace MovieShop.UnitTests
{
       /*
    Arrange: Initializes objects, creates mocks with arguments that are passed to the method 
    under test and adds expectations.

    Act: Invokes the method or property under test with the arranged parameters.

    Assert: Verifies that the action of the method under test behaves as expected.
    */

    // The TestClass attribute denotes a class that contains unit tests
    [TestClass]
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _mockMovieRepository;
        private readonly IMovieService _movieService;
        private List<Genre> _genres;
        private List<Movie> _movies;

        public MovieServiceTests()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockMovieRepository.Object);
        }

        /// <summary>
        ///     Triggered before every test case.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange

            _genres = new List<Genre>
                      {
                          new Genre {Id = 1, Name = "Action"},
                          new Genre {Id = 2, Name = "Crime"},
                          new Genre {Id = 3, Name = "Drama"}
                      };

            _movies = new List<Movie>
                      {
                          new Movie
                          {
                              Id = 1,
                              Title = "TestMovie1",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1 || g.Id == 2).ToList()
                          },
                          new Movie
                          {
                              Id = 2,
                              Title = "TestMovie2",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1 || g.Id == 2).ToList()
                          },
                          new Movie
                          {
                              Id = 3,
                              Title = "TestMovie3",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 2 || g.Id == 3).ToList()
                          },
                          new Movie
                          {
                              Id = 4,
                              Title = "TestMovie4",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1 || g.Id == 3).ToList()
                          },
                          new Movie
                          {
                              Id = 5,
                              Title = "TestMovie5",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1).ToList()
                          }
                      };

            _mockMovieRepository.Setup(m => m.GetTopGrossingMovies()).Returns(_movies);
            _mockMovieRepository.Setup(mo => mo.GetById(It.IsAny<int>()))
                                .Returns((int m) => _movies.FirstOrDefault(x => x.Id == m));
        }

        /// <summary>
        ///     One-time triggered method before test cases start
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
        }


        /// <summary>
        /// </summary>
        [TestMethod]
        public void TestTopGrossingMoviesFromFakeData()
        {
            var movies = _movieService.GetTopGrossingMovies();

            // assert
            Assert.IsInstanceOfType(movies, typeof(IEnumerable<Movie>));
            Assert.IsNotNull(movies);
            Assert.AreEqual(5, movies.Count());
            CollectionAssert.AllItemsAreInstancesOfType(movies.ToList(), typeof(Movie));
        }

        /// <summary>
        ///     A DataTestMethod attribute represents a suite of tests that execute the same code but have different input
        ///     arguments.
        ///     You can use the DataRow attribute to specify values for those inputs.
        /// </summary>
        /// <param name="genreId"></param>
        [DataTestMethod]
        [DataRow(1)]
        public void TestMovieByIdFromFakeData(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId);

            // assert
            //Assert.IsInstanceOfType(movies, typeof(IEnumerable<Movie>));
            //Assert.IsNotNull(movies);
            //Assert.AreEqual(5, movies.Count());
            //CollectionAssert.AllItemsAreInstancesOfType(movies.ToList(), typeof(Movie));
        }
    }
}