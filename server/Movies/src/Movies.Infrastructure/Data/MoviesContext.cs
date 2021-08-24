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

        void IMoviesContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
