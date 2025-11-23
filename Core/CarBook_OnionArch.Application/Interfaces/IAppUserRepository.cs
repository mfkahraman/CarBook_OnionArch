using CarBook_OnionArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IAppUserRepository
    {
        Task<IdentityResult> AddUserToRoleAsync(AppUser user, string role);
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task<IdentityResult> DeleteUserAsync(int id);
        Task<AppUser?> FindUserByUserNameAsync(string username);
        Task<AppUser?> FindUserByIdAsync(int id);
    }
}