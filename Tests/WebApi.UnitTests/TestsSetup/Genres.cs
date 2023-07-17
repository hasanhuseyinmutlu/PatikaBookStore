using WebApi.DBOperation;
using WebApi.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void addGenres(this BookStoreDbContext context)
        {
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
        }
    }
}