using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Core.Contracts.Actors;
using MoviesApp.Infrastructure.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetActorsRequest request)
        {
            try
            {
                var actorsResponse = await _actorService.GetAllActors(request);
                return Ok(actorsResponse);
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
                var actor = await _actorService.GetActorDetails(id);
                if (actor == null)
                    return NotFound(); // Return 404 Not Found if actor is not found
                return Ok(actor);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(AddActorRequest request)
        {
            try
            {
                var actorItem = await _actorService.AddActor(request);
                return Ok(actorItem);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateActorRequest request)
        {
            try
            {
                var actorItem = await _actorService.UpdateActor(request);
                if (actorItem == null)
                    return NotFound(); // Return 404 Not Found if actor is not found
                return Ok(actorItem);
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
                _actorService.Delete(id);
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

