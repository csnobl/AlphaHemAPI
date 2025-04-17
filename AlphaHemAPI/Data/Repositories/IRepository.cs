namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
