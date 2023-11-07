using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soft_Alliance.APP.Domain.Dtos;
using Soft_Alliance.APP.Features.MovieMgt.Commands.CreateMovie;
using Soft_Alliance.APP.Features.MovieMgt.Commands.DeleteMovie;
using Soft_Alliance.APP.Features.MovieMgt.Commands.UpdateMovie;
using Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovie;
using Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovies;

namespace Soft_Alliance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMovieByIdAsync([FromQuery] GetMovieQuery query, 
            [FromServices] GetMovieQueryHandler handler)
        {
            if (query is null) return BadRequest("query cannot be null");

            var validate = query.Validate();
            if (validate.NotSucceeded)
                return StatusCode((int)validate.Code, validate.Message);

            var result = await handler.HandleAsync(query);
            if (result.NotSucceeded)
                return StatusCode((int)result.Code, result.Message);

            return StatusCode((int)result.Code, result);
        }

        [HttpGet("movies")]
        public async Task<IActionResult> GetMoviesAsync([FromQuery] QueryParamsDto queryParams,
            [FromServices] GetMoviesQueryHandler handler)
        {
            var query = new GetMoviesQuery { Params = queryParams };

            var validate = query.Validate();
            if (validate.NotSucceeded)
                return StatusCode((int)validate.Code, validate.Message);

            var result = await handler.HandleAsync(query);
            if (result.NotSucceeded)
                return StatusCode((int)result.Code, result.Message);

            return StatusCode((int)result.Code, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync([FromForm] CreateMovieCommand command,
            [FromServices] CreateMovieCommandHandler handler)
        {
            if (command is null) return BadRequest("Request body cannot be null");

            var validate = command.Validate();
            if (validate.NotSucceeded)
                return StatusCode((int)validate.Code, validate.Message);

            var result = await handler.HandleAsync(command);
            if (result.NotSucceeded)
                return StatusCode((int)result.Code, result.Message);

            return StatusCode((int)result.Code, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovieAsync([FromForm] UpdateMovieCommand command,
            [FromServices] UpdateMovieCommandHandler handler)
        {
            if (command is null) return BadRequest("Request body cannot be null");

            var validate = command.Validate();
            if (validate.NotSucceeded)
                return StatusCode((int)validate.Code, validate.Message);

            var result = await handler.HandleAsync(command);
            if (result.NotSucceeded)
                return StatusCode((int)result.Code, result.Message);

            return StatusCode((int)result.Code, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovieAsync([FromBody] DeleteMovieCommand command,
            [FromServices] DeleteMovieCommandHandler handler)
        {
            if (command is null) return BadRequest("Request body cannot be null");

            var validate = command.Validate();
            if (validate.NotSucceeded)
                return StatusCode((int)validate.Code, validate.Message);

            var result = await handler.HandleAsync(command);
            if (result.NotSucceeded)
                return StatusCode((int)result.Code, result.Message);

            return StatusCode((int)result.Code, result);
        }
    }
}
