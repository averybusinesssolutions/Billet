namespace Billet.Server.Data
{
    public interface IRepository<T>
    {
        public Task<T> GetAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task SaveAsync(T entity);
    }
}
