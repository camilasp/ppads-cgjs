using Application.Interfaces;
using Domain.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TipFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class MovieController : Controller
    {
        private readonly IHandler _handler;

        public MovieController(IHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("PopularMovies")]
        public async Task<ActionResult<ICollection<MinimalMovieDTO>>> Get()
        {
            try
            {
                var moviesInfo = await _handler.GetPopularMoviesAsync();
                return Ok(moviesInfo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("MovieInfo")]
        public async Task<ActionResult<MovieFavDTO>> Get([FromQuery] Guid guid, int id)
        {
            try
            {
                var movie = await _handler.GetMovieByIdAsync(guid, id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
