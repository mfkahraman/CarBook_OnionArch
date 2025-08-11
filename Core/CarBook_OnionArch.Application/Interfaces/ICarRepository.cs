using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsWithBrandsAsync();
        Task<List<Car>> GetCarsWithAllAsync();
        Task<List<Car>> GetLast5CarsAsync();
    }
}
