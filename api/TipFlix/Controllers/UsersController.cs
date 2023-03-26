using Application.Interfaces;
using Domain.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TipFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly IHandler _handler;

        public UsersController(IHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("Login/{email}/{password}")]
        public async Task<ActionResult<UserDTO>> LoginAsync(string email, string password)
        {
            return Ok("Sucessful login");
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> PostAsync([FromBody] UserDTO userDTO)
        {
            if (userDTO is not null)
            {
                return Ok("Registered new user");
            }
            else
            {
                return BadRequest("Sended a null object");
            }
        }

        [HttpPut("UpdateMovieList")]
        public async Task<ActionResult> UpdateMovieListAsync([FromBody] UserDTO userDTO)
        {
            return Ok($"New movie list for user[{userDTO.Email}]");
        }

        [HttpDelete("Delete/{guid:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid guid)
        {
            return Ok($"Deleted user[{guid}]");
        }
    }
}
