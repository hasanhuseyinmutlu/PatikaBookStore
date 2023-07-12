using Microsoft.EntityFrameworkCore;

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
        {}
        public DbSet<Book> Books {get; set;}


    }
}