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

        [HttpGet("Get")]
        public async Task<ActionResult<UserDTO>> LoginAsync([FromQuery] Guid guid)
        {
            try
            {
                var userDto = await _handler.GetUserByIdAsync(guid);
                return userDto is not null ? (ActionResult<UserDTO>)Ok(userDto) : (ActionResult<UserDTO>)NotFound("Usuário não cadastrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("Login")]
        public async Task<ActionResult<UserDTO>> LoginAsync([FromQuery] string email, string password)
        {
            try
            {
                var userDto = await _handler.LoginUserAsync(email, password);
                return userDto is not null ? (ActionResult<UserDTO>)Ok(userDto) : (ActionResult<UserDTO>)NotFound("Usuário não cadastrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> PostAsync([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO is not null)
                {
                    await _handler.CreateUserAsync(userDTO);
                    return Ok("Registrado novo usuário.");
                }
                else
                {
                    return BadRequest("Envio objeto nulo.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateMovieList")]
        public async Task<ActionResult> UpdateMovieListAsync([FromBody] UpdateMovieListDTO updateMovieListDTO)
        {
            try
            {
                await _handler.UpdateUserMovieListAsync(updateMovieListDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] Guid guid)
        {
            try
            {
                await _handler.DeleteUserAsync(guid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
