using Microsoft.AspNetCore.Mvc;
using WriteMoreAPI.DAL.Repository;
using WriteMoreAPI.Model;

namespace WriteMoreAPI.Controllers
{
    public class MovieController: Controller
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieController(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("/api/movie")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("/api/movie/{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            return Ok(movie);
        }

        [HttpPost("/api/movie")]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            var movieAdded = await _movieRepository.CreateAsync(movie);
            return Ok(movieAdded);
        }

        [HttpPost("/api/movie/{id}")]
        public async Task RemoveMovie(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }
    }
}
