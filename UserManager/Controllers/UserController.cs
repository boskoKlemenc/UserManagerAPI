using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using UserManagerAPI.DTOs;
using UserManagerAPI.Services;

namespace UserManagerAPI.Controllers
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
        public async Task<ActionResult> CreateUser(CreateUserRequest request)
        {
            var result = await _userService.CreateUserAsync(request);

            if (result.error != null)
                return Conflict(new { message = result.error });

            return CreatedAtAction(nameof(GetUser), new { id = result.id }, new { id = result.id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(Guid id, UpdateUserRequest request)
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

            return Ok();
        }

        [HttpPost("validate-password")]
        public async Task<ActionResult> ValidatePassword([FromBody] ValidatePasswordRequest request)
        {
            var isValid = await _userService.ValidatePasswordAsync(request.Username, request.Password);

            return Ok(new { isValid });
        }
    }
}
