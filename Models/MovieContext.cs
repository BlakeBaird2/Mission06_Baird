using Microsoft.EntityFrameworkCore;

namespace Mission06_Baird.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Category = "Sci-Fi", Title = "Inception", Year = 2010, Director = "Christopher Nolan", Rating = "PG-13", Edited = false, LentTo = "", Notes = "Wow" },
                new Movie { MovieId = 2, Category = "Drama", Title = "The Shawshank Redemption", Year = 1994, Director = "Frank Darabont", Rating = "R", Edited = true, LentTo = "Joel", Notes = "Classic" },
                new Movie { MovieId = 3, Category = "Action", Title = "The Dark Knight", Year = 2008, Director = "Christopher Nolan", Rating = "PG-13", Edited = false, LentTo = "", Notes = "Batman" }
            );
        }
    }
}