using UserManagerAPI.DTOs;

namespace UserManagerAPI.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetUserAsync(Guid id);
        Task<UserDto> CreateUserAsync(CreateUserRequest request);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserDto?> UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task<bool> ValidatePasswordAsync(string userName, string password);
    }
}
