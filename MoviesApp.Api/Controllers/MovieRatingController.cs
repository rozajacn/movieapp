using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Core.Contracts.MovieRatings;
using MoviesApp.Infrastructure.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieRatingController : Controller
    {
        private readonly IMovieRatingService _movieRating;

        public MovieRatingController(IMovieRatingService movieRating)
        {
            _movieRating = movieRating;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddMovieActorItem(AddMovieRatingRequest request)
        {
            try
            {
                await _movieRating.AddMovieRating(request);
                return NoContent(); // Return 204 No Content on successful execition
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}

