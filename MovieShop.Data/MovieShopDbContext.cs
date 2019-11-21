using System.Data.Entity;
using MovieShop.Entities;

namespace MovieShop.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext()
            : base("name=MovieShopDbContext")
        {
        }

        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Crew> Crews { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<MovieCrew> MovieCrews { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Movies)
                .WithMany(e => e.Genres)
                .Map(m => m.ToTable("MovieGenre").MapLeftKey("GenreId").MapRightKey("MovieId"));

            modelBuilder.Entity<Movie>()
                .Property(e => e.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Review>()
                .Property(e => e.Rating)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
