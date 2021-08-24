using Movies.Domain;
using Movies.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Helpers
{
    public static class Seeder
    {
        public static void Seed(IMoviesContext moviesContext,IEnumerable<Movie> movies)
        {
            moviesContext.Movies.AddRange(movies);
            moviesContext.SaveChanges();
        }
    }
}
