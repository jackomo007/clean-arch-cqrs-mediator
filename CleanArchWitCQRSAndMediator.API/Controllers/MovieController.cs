using CleanArchWitCQRSAndMediator.Application.Movies.Commands.CreateMovie;
using CleanArchWitCQRSAndMediator.Application.Movies.Commands.DeleteMovie;
using CleanArchWitCQRSAndMediator.Application.Movies.Commands.UpdateMovie;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieCommand command)
        {
            var createMovie = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = createMovie.Id }, createMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMovieCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMovieCommand { Id = id});
            return NoContent();
        }

    }
}
