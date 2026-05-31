using UserManagerAPI.DTOs;

namespace UserManagerAPI.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetUserAsync(Guid id);
        Task<UserDto> CreateUserAsync(UserDto request);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserDto?> UpdateUserAsync(Guid id, UserDto request);
        Task<bool> ValidatePasswordAsync(string userName, string password);
    }
}
