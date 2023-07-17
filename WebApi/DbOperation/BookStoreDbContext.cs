using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperation
{
    public class BookStoreDbContext :DbContext,IBookStoreDbContext
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
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public override int SaveChanges()
        {
           return base.SaveChanges();
        }
    }
}