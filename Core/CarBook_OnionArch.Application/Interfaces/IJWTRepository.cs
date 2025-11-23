using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IJWTRepository
    {
        Task<string> CreateTokenAsync(string userName);
    }
}
