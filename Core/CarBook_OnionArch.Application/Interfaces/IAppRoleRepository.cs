using CarBook_OnionArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IAppRoleRepository
    {
        Task<bool> IsRoleExistAync(string roleName);
        Task<IdentityResult> CreateRoleAsync(AppRole roleName);

    }
}
