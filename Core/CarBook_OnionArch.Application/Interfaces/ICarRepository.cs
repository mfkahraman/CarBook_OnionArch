using CarBook_OnionArch.Domain.Entities;
using System.Linq.Expressions;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsWithBrandsAsync();
        Task<List<Car>> GetCarsWithAllAsync();
        Task<Car> GetCarWithRelationsById(int id);
        Task<List<Car>> GetCarsByFilterAsync(Expression<Func<Rental, bool>> filter);
    }
}
