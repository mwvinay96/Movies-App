using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMoviesContext moviesContext;

        public MoviesController(IMoviesContext moviesContext)
        {
            this.moviesContext = moviesContext;
        }

        [HttpGet("allMovies")]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            var result = await moviesContext.GetAllMovies();
            return Ok(result);
        }
    }
}
