using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.API.NewFolder;
using Movies.Application.Services;
using Movies.Domain;
using Movies.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("allMovies")]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            try
            {

                var result = await movieService.GetAllMovies();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("movie")]
        public async Task<IActionResult> GetMovieById(string imdbID)
        {
            try
            {
                var result = await movieService.GetMovieById(imdbID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDto movieDto)
        {
            try
            {
                var movie = new Movie(movieDto.Language, movieDto.Location, movieDto.Plot, movieDto.Poster, new List<string>(), new List<string>(), movieDto.Title,
                                movieDto.ImdbId, movieDto.ListingType, movieDto.Rating.ToString());

                await movieService.Addmovie(movie);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
