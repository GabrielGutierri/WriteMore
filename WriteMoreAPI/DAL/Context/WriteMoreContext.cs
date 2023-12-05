using Microsoft.EntityFrameworkCore;
using WriteMoreAPI.Model;

namespace WriteMoreAPI.DAL.Context
{
    public class WriteMoreContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public WriteMoreContext(DbContextOptions<WriteMoreContext> options): base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(WriteMoreConnection.ConnectionConfig.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(b => b.HasKey("ID"));
            modelBuilder.Entity<Movie>(m => m.HasKey("ID"));
        }
    }
}
