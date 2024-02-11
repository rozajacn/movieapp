using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Core.Contracts.Movies;
using MoviesApp.Infrastructure.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetMoviesRequest request)
        {
            try
            {
                var moviesResponse = await _movieService.GetAllMovies(request);
                return Ok(moviesResponse);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var movie = await _movieService.GetMovieDetails(id);
                if (movie == null)
                    return NotFound(); // Return 404 Not Found if movie is not found
                return Ok(movie);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(AddMovieItemRequest request)
        {
            try
            {
                var movieItem = await _movieService.AddMovie(request);
                return Ok(movieItem);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateMovieItemRequest request)
        {
            try
            {
                var movieItem = await _movieService.UpdateMovie(request);
                if (movieItem == null)
                    return NotFound(); // Return 404 Not Found if movie is not found
                return Ok(movieItem);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [Authorize]
        [HttpPost("assignactor")]
        public async Task<IActionResult> AddMovieActorItem(AddMovieActorAssociationRequest request)
        {
            try
            {
                var item = await _movieService.AddMovieActor(request);
                if (item == false)
                    return StatusCode(500, "An error occurred while processing your request"); ; // Return 404 Not Found if movie is not found
                return Ok("Movie-actor association added successfully"); 
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _movieService.Delete(id);
                return NoContent(); // Return 204 No Content on successful deletion
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}

