using Microsoft.AspNetCore.Mvc;
using WriteMore.Domain.Interfaces.Services;
using WriteMore.Domain.Models;

namespace WriteMoreAPI.Controllers
{
    public class MovieController: Controller
    {
        private readonly IService<Movie> _movieService;

        public MovieController(IService<Movie> movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("/api/movie")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("/api/movie/{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetAsync(id);
            return Ok(movie);
        }

        [HttpPost("/api/movie")]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            var movieAdded = await _movieService.CreateAsync(movie);
            return Ok(movieAdded);
        }

        [HttpPost("/api/movie/{id}")]
        public async Task RemoveMovie(int id)
        {
            await _movieService.DeleteAsync(id);
        }
    }
}
