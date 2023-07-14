using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperation
{
    public class BookStoreDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookStoreDB");
        }
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres {get; set;}

        public List<Book> GetBooksFromDatabase()
        {
            return Books.ToList();
        }

    }
}