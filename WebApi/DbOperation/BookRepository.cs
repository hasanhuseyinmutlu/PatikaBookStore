using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.DBOperation;
using WebApi.Entities;

namespace WebApi.DBOperation
{
    public class BookRepository
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return; // data seeded
                }
                context.Authors.AddRange(
                    new Author
                    {
                        
                        Name = "William",

                        Surname = "Gibson",

                        BirthDay = new DateTime(1948,03,17)

                        
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Science Fiction"
                    },

                    new Genre
                    {
                        Name = "Noval"
                    },

                    new Genre
                    {
                        Name = "Utopia"
                    }
                );

                context.Books.AddRange(
                    new Book()
                    {
                        // Id = 1,
                        Title = "Mona Lisa Overdrive",
                        GenreId = 1, // Science Fiction
                        PageCount = 360,
                        PublishDate = new DateTime(1988, 06, 12)
                    },
                    new Book()
                    {
                        // Id = 2,
                        Title = "Count Zero",
                        GenreId = 1, // Sciance Fiction
                        PageCount = 256,
                        PublishDate = new DateTime(1986, 01, 14)
                    },
                    new Book()
                    {
                        // Id = 3,
                        Title = "Neuromancer",
                        GenreId = 1, // Sciance Fiction
                        PageCount = 271,
                        PublishDate = new DateTime(1984, 07, 01)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}