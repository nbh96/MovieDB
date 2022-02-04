using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options)
        {

        }
        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "RomCom" },
                new Category { CategoryId = 3, CategoryName = "Documentary" },
                new Category { CategoryId = 4, CategoryName = "History" },
                new Category { CategoryId = 5, CategoryName = "Mockumentary" }
                );

            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    ApplicationId = 1,
                    CategoryId = 1,
                    Title = "Batman Begins",
                    Year = 2005,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    ApplicationId = 2,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    ApplicationId = 3,
                    CategoryId = 1,
                    Title = "The Dark Knight Rises",
                    Year = 2012,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
