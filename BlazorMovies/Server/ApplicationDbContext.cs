using BlazorMovies.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define the composite key of MovieActors
            modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId});
            modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenresId });

            base.OnModelCreating(modelBuilder);
        }
        //Tables in our db from entity
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }

    }
}
