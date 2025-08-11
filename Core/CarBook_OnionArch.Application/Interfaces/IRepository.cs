namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IRepository<IEntity>
    {
        Task<List<IEntity>> GetAllAsync();
        Task<IEntity> GetByIdAsync(int id);
        bool Create(IEntity entity);
        bool Update(IEntity entity);
        Task<bool> RemoveAsync(int id);
    }
}
