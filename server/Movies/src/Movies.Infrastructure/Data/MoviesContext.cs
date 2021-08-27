using Microsoft.EntityFrameworkCore;
using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Data
{
    public class MoviesContext : DbContext, IMoviesContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await Movies.AsNoTracking().ToListAsync();
        }

        public async Task<Movie> GetMovieById(string imdbId)
        {
            return await Movies.AsNoTracking().FirstOrDefaultAsync(e => e.ImdbID == imdbId);
        }
        void IMoviesContext.SaveChanges()
        {
            this.SaveChanges();
        }

        public async Task Addmovie(Movie movie)
        {
            this.Movies.Add(movie);
            await this.SaveChangesAsync();
        }
    }
}
