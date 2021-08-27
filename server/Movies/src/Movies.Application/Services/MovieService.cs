using Movies.Application.Services;
using Movies.Domain;
using Movies.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesContext moviesContext;

        public MovieService(IMoviesContext moviesContext)
        {
            this.moviesContext = moviesContext;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await this.moviesContext.GetAllMovies();
        }

        public Task<Movie> GetMovieById(string imdbId)
        {
            return this.moviesContext.GetMovieById(imdbId);
        }

        public async Task Addmovie(Movie movie)
        {
            await moviesContext.Addmovie(movie);
        }
    }
}
