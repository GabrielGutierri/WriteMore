using WriteMoreAPI.DAL.Context;
using WriteMoreAPI.Model;

namespace WriteMoreAPI.DAL.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly WriteMoreContext _context;
        public BookRepository(WriteMoreContext context)
        {
            _context = context;
        }
        public Task<Book> CreateAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateAsync(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
