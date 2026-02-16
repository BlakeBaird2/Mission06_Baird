using Microsoft.EntityFrameworkCore;

namespace Mission06_Baird.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed category data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror" },
                new Category { CategoryId = 6, CategoryName = "Sci-Fi" },
                new Category { CategoryId = 7, CategoryName = "Thriller" },
                new Category { CategoryId = 8, CategoryName = "Romance" },
                new Category { CategoryId = 9, CategoryName = "Documentary" },
                new Category { CategoryId = 10, CategoryName = "Animation" },
                new Category { CategoryId = 11, CategoryName = "Musical" },
                new Category { CategoryId = 12, CategoryName = "Western" },
                new Category { CategoryId = 13, CategoryName = "Disney" },
                new Category { CategoryId = 14, CategoryName = "Adventure" },
                new Category { CategoryId = 15, CategoryName = "Fantasy" }
            );

            // Seed movie data
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 6, // Sci-Fi
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    CopiedToPlex = false,
                    LentTo = "",
                    Notes = "Wow"
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 3, // Drama
                    Title = "The Shawshank Redemption",
                    Year = 1994,
                    Director = "Frank Darabont",
                    Rating = "R",
                    Edited = true,
                    CopiedToPlex = true,
                    LentTo = "Joel",
                    Notes = "Classic"
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryId = 1, // Action
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    CopiedToPlex = false,
                    LentTo = "",
                    Notes = "Batman"
                },
                new Movie
                {
                    MovieId = 4,
                    CategoryId = 13, // Disney
                    Title = "Frozen",
                    Year = 2013,
                    Director = "Chris Buck and Jennifer Lee",
                    Rating = "PG",
                    Edited = false,
                    CopiedToPlex = false,
                    LentTo = null,
                    Notes = null
                }
            );
        }
    }
}
