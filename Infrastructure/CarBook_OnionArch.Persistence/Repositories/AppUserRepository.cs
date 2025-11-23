using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class AppUserRepository(UserManager<AppUser> userManager) : IAppUserRepository
    {
        public async Task<IdentityResult> AddUserToRoleAsync(int userId, string role)
        {
            var user = await FindUserByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found.", nameof(userId));
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Role cannot be null or empty.", nameof(role));
            }
            return await userManager.AddToRoleAsync(user, role);
        }

        public async Task<bool> CheckPasswordAsync(int userId, string password)
        {
            var user = await FindUserByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found.", nameof(userId));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }
            return await userManager.CreateAsync(user, password);
        }

        public async Task<AppUser?> FindUserByUserNameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }
            return await userManager.FindByNameAsync(username);
        }

        public async Task<AppUser?> FindUserByIdAsync(int id)
        {
            return await userManager.FindByIdAsync(id.ToString());
        }

        public async Task<IdentityResult> DeleteUserAsync(int id)
        {
            var user = await FindUserByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found.", nameof(id));
            }
            return await userManager.DeleteAsync(user);
        }
    }
}
