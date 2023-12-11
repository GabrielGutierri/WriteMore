using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteMore.Domain.Interfaces.Repository;
using WriteMore.Domain.Interfaces.Services;
using WriteMore.Domain.Models;

namespace WriteMore.Domain.Services
{
    public class BookService : IService<Book>
    {
        private readonly IRepository<Book> _repository;
        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<Book> CreateAsync(Book entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
