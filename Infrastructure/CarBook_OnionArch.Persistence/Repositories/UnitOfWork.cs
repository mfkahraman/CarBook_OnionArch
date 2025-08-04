using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Persistence.Context;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class UnitOfWork(CarBookContext context) : IUnitOfWork
    {
        public async Task<bool> CommitAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
