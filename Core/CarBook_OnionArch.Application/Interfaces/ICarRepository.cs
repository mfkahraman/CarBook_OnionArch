using CarBook_OnionArch.Domain.Entities;
using System.Linq.Expressions;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsWithBrandsAsync();
        Task<List<Car>> GetCarsWithAllAsync();
        Task<Car> GetCarWithRelationsById(int id);
        Task<List<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }
}
