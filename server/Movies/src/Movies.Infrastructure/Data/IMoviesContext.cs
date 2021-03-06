using Microsoft.EntityFrameworkCore;
using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Data
{
    public interface IMoviesContext
    {
        public DbSet<Movie> Movies { get; set; }
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(string imdbId);
        Task Addmovie(Movie movie);
        void SaveChanges();
    }
}
