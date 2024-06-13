using Books.Api.Application.DTOs.AuthorDto;
using Books.Api.Application.DTOs.Book;
using Books.Api.Application.Response;
using Books.Api.Core.Entities;

namespace Books.Api.Core.Services.Interface
{
    public interface IBookService
    {
        Task<ResponseModel<List<Book>>> ListBooks(); //-> Lista todos os authores
        Task<ResponseModel<Book>> GetBookById(int idBook); //-> Busca o author referente ao Id dele
        Task<ResponseModel<List<Book>>> GetBookByIdAuthor(int idAutor); //-> Busca o author referente ao Id dele
        Task<ResponseModel<List<Book>>> CreateBook(CreateBookDto createBookDto);
        Task<ResponseModel<List<Book>>> EditBook(EditBookDto editBookDto);
        Task<ResponseModel<List<Book>>> RemoveBook(int idBook);
    }
}
