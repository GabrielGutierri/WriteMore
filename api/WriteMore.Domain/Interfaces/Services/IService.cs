using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMore.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
