using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class AppRoleRepository(RoleManager<AppRole> roleManager) : IAppRoleRepository
    {
        public async Task<AppRole> GetAppRoleById(int appRoleId)
        {
            var role = await roleManager.FindByIdAsync(appRoleId.ToString());
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return role;
        }
        public async Task<IdentityResult> CreateRoleAsync(AppRole roleName)
        {
            if (roleName == null)
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            return await roleManager.CreateAsync(roleName);
        }

        public async Task<bool> IsRoleExistsAync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            return await roleManager.RoleExistsAsync(roleName);
        }

        public async Task<IdentityResult> DeleteRoleAsync(int roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return await roleManager.DeleteAsync(role);
        }
    }
}