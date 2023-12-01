namespace WriteMoreAPI.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
