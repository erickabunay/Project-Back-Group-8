using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userRepository.GetAllAsync();
            return Ok(user);
        }

        [HttpGet("{id}/id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{name}/name")]
        public async Task<IActionResult> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{lastName}/lastName")]
        public async Task<IActionResult> GetUserByLastNameAsync(string lastName)
        {
            var user = await _userRepository.GetByLastNameAsync(lastName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("/role/manager")]
        public async Task<IActionResult> GetAllUserByRoleManagerAsync()
        {
            var user = await _userRepository.GetAllUserByRoleManagerAsync();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("/role/client")]
        public async Task<IActionResult> GetAllUserByRoleClientAsync()
        {
            var user = await _userRepository.GetAllUserByRoleClientAsync();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("email/password")]
        public async Task<IActionResult> GetByEmailAndPassword([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            var user = await _userRepository.GetByEmailAndPassword(request.Email, request.Password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos del Usuario Invalidos");
            }
            await _userRepository.CreateAsync(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("El Id "+ id +" del usuario no existe.");
            }

            var updatedUser = await _userRepository.UpdateAsync(user);

            if (updatedUser != null)
            {
                return Ok(updatedUser);
            }
            else
            {
                return NotFound("El usuario con el Id "+ id +" no existe.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }
            await _userRepository.DisableByIdAsync(id);
            return Ok("Usuario eliminado correctamente");
        }
    }
}
