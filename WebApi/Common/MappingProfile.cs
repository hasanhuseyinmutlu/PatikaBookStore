using AutoMapper;
using WebApi.addControllers;
using WebApi.Aplication.BooksOperations.GetBook;
using WebApi.Entities;
using static WebApi.Aplication.BooksOperations.CreateBook.CreateBookCommand;
using static WebApi.Aplication.GenreOperations.Queries.GetGenreDetailQuery;
using static WebApi.Aplication.GenreOperations.Queries.GetGenresQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // createbook object can mapping book object
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenresViewModel    >();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}