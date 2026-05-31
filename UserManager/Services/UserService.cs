using System;
using UserManagerAPI.DTOs;
using DataAccess.Entities;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace UserManagerAPI.Services
{
    public class UserService: IUserService
    {
        private readonly MainDbContext _db;

        public UserService(MainDbContext db)
        {
            _db = db;
        }

        public async Task<UserDto> CreateUserAsync(UserDto request)
        {
            var user = new User
            {
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                Language = request.Language,
                Culture = request.Culture,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return MapToDto(user);
        }

        public async Task<UserDto?> GetUserAsync(Guid id)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            return MapToDto(user);
        }

        public async Task<UserDto?> UpdateUserAsync(Guid id, UserDto request)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            user.UserName = request.UserName;
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.MobileNumber = request.MobileNumber;
            user.Language = request.Language;
            user.Culture = request.Culture;

            await _db.SaveChangesAsync();

            return MapToDto(user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return false;

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ValidatePasswordAsync(string userName, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }

        #region helpers
        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                MobileNumber = user.MobileNumber,
                Language = user.Language,
                Culture = user.Culture
            };
        }
        #endregion 
    }
}
