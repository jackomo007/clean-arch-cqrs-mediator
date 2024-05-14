using CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovieById;
using CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWitCQRSAndMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await Mediator.Send(new GetMovieQuery());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var movie = await Mediator.Send(new GetMovieByIdQuery() { MovieId=id});
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

    }
}
