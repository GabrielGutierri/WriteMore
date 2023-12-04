using Microsoft.EntityFrameworkCore;
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
        public async Task<Book> CreateAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.ID == id);
            if(book != null)
                _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _context.Books.Where(b => b.ID == id).FirstOrDefaultAsync();

        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            _context.Books.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
