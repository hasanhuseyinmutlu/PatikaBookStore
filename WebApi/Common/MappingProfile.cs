using AutoMapper;
using BookStoreWebApi.Application.UserOperations.Commands.Create;
using WebApi.Aplication.AuthorOperations.Command.CreateAuthor;
using WebApi.Aplication.BooksOperations.GetBook;
using WebApi.Application.AuthorOperations.Queries;
using WebApi.Application.BookOperations.GetBooks;
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
            CreateMap<Book, GetBooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Author, AuthorsViewModel>();
            CreateMap<CreateAuthorViewModel, Author>();

            CreateMap<CreateUserModel, User>();
        }
    }
}