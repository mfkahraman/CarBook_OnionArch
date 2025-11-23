using CarBook_OnionArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IAppRoleRepository
    {
        Task<AppRole> GetAppRoleById(int appRoleId);
        Task<bool> IsRoleExistsAync(string roleName);
        Task<IdentityResult> CreateRoleAsync(AppRole role);
        Task<IdentityResult> DeleteRoleAsync(int roleId);
    }
}