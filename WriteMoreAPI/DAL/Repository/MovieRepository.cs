using Microsoft.EntityFrameworkCore;
using WriteMoreAPI.DAL.Context;
using WriteMoreAPI.Model;

namespace WriteMoreAPI.DAL.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly WriteMoreContext _context;
        public MovieRepository(WriteMoreContext context)
        {
            _context = context;
        }
        public async Task<Movie> CreateAsync(Movie entity)
        {
            await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == id);
            if (movie != null)
                _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _context.Movies.Where(b => b.ID == id).FirstOrDefaultAsync();
        }

        public async Task<Movie> UpdateAsync(Movie entity)
        {
            _context.Movies.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
