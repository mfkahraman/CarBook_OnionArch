using CarBook_OnionArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IAppUserRepository
    {
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<IdentityResult> AddUserToRoleAsync(AppUser user, string role);
        Task<AppUser?> FindUserByUserNameAsync(string username);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
    }
}