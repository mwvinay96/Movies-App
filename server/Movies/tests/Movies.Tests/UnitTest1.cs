using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Movies.API;
using Movies.Domain;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.IO;
using Movies.API.NewFolder;
using System.Text;

namespace Movies.Tests
{
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UnitTest1()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
                .UseStartup<Startup>());
            _client = _server.CreateClient();

        }
        [Fact]
        public async Task GetAllMovies()
        {
            var response = await _client.GetAsync("api/movies/allmovies");
            var res = JsonConvert.DeserializeObject<IEnumerable<Movie>>(await response.Content.ReadAsStringAsync());
            res.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GetMovieById()
        {
            var moviesRes = await _client.GetAsync("api/movies/allmovies");
            var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(await moviesRes.Content.ReadAsStringAsync());

            var movieRes = await _client.GetAsync($"api/movies/movie?imdbId={movies.First().ImdbID}");
            var res = JsonConvert.DeserializeObject<Movie>(await movieRes.Content.ReadAsStringAsync());

            res.ShouldNotBeNull();
        }

        [Fact]
        public async Task AddMovie()
        {
            var movie = new MovieDto()
            {
                ImdbId = "tt0409459",
                Language = "English",
                ListingType = Domain.Models.ListingType.NOW_SHOWING,
                Location = "UDUPI",
                Plot = "In 1985 where former superheroes exist, the murder of a colleague sends active vigilante Rorschach into his own sprawling investigation, uncovering something that could completely change the course of history as we know it.",
                Poster = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/3603bdf4-2419-4aa3-a515-21ab3bae8739/d1pqkgz-59b4b135-fc60-4d60-9bee-303c20fd5ba9.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzM2MDNiZGY0LTI0MTktNGFhMy1hNTE1LTIxYWIzYmFlODczOVwvZDFwcWtnei01OWI0YjEzNS1mYzYwLTRkNjAtOWJlZS0zMDNjMjBmZDViYTkucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Rkfcf7392hLfnys3lu0iIbjtZkKOSenmxiXiTRgeQ-Y",
                Rating = 10,
                Title = "WATCHMEN"
            };
            var httpContent = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/movies", httpContent);
            res.EnsureSuccessStatusCode();

            var movieRes = await _client.GetAsync($"api/movies/movie?imdbId={movie.ImdbId}");
            var newMovie = JsonConvert.DeserializeObject<Movie>(await movieRes.Content.ReadAsStringAsync());

            newMovie.ShouldNotBeNull();
        }
    }
}
