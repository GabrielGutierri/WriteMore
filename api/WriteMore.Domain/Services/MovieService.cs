using WriteMore.Domain.Interfaces.Repository;
using WriteMore.Domain.Interfaces.Services;
using WriteMore.Domain.Models;

namespace WriteMore.Domain.Services
{
    public class MovieService : IService<Movie>
    {
        private readonly IRepository<Movie> _repository;
        public MovieService(IRepository<Movie> repository)
        {
           _repository = repository;
        }
        public async Task<Movie> CreateAsync(Movie entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public Task<Movie> UpdateAsync(Movie entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
