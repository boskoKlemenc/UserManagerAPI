using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using UserManagerAPI.DTOs;
using UserManagerAPI.Services;

namespace UserManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto request)
        {
            var createdUser = await _userService.CreateUserAsync(request);

            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(Guid id, UserDto request)
        {
            var user = await _userService.UpdateUserAsync(id, request);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var deleted = await _userService.DeleteUserAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPost("validate-password")]
        public async Task<ActionResult<bool>> ValidatePassword(ValidatePasswordRequest request)
        {
            var isValid = await _userService.ValidatePasswordAsync(request.Username, request.Password);

            return Ok(isValid);
        }
    }
}
