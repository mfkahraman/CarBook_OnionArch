using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Application.Options;
using CarBook_OnionArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class JWTRepository(IOptions<Application.Options.TokenOptions> tokenOptions,
                               UserManager<AppUser> userManager,
                               JwtSecurityTokenHandler jwtHandler)
        : IJWTRepository
    {
        private readonly Application.Options.TokenOptions _tokenOptions = tokenOptions.Value;

        public async Task<string> CreateTokenAsync(string userName)
        {
            if (string.IsNullOrEmpty(_tokenOptions.Key))
                throw new InvalidOperationException("JWT signing key is not configured.");

            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            var userRoles = await userManager.GetRolesAsync(user);

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Role, userRoles.FirstOrDefault() ?? string.Empty),
                new Claim("fullName", String.Join("", user.FirstName, user.LastName)),
            };

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_tokenOptions.Key));

            JwtSecurityToken jwtSecurityToken = new(
                    issuer: _tokenOptions.Issuer,
                    audience: _tokenOptions.Audience,
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(_tokenOptions.ExpireInMinutes),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                    );
            var token = jwtHandler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
