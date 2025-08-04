namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        bool Create(T entity);
        bool Update(T entity);
        Task<bool> RemoveAsync(int id);
    }
}
