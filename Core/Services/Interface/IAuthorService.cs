using Books.Api.Application.DTOs.AuthorDto;
using Books.Api.Application.Response;
using Books.Api.Core.Entities;

namespace Books.Api.Core.Services.Interface
{
    public interface IAuthorService
    {
        //O meu responseModel e generico, entao eu posso passar qualquer coisa para ele
        //Ele vai envolver o modelo que eu passar em um Objeto tipo Data { modelo author...}
        Task<ResponseModel<List<Author>>> ListAuthors(); //-> Lista todos os authores
        Task<ResponseModel<Author>> GetAuthorById(int idAuthor); //-> Busca o author referente ao Id dele
        Task<ResponseModel<Author>> GetAuthorByIdBook(int idBook); //-> Busca o author referente ao Id dele
        Task<ResponseModel<List<Author>>> CreateAuthor(CreateAuthorDto createAuthorDto);
        Task<ResponseModel<List<Author>>> EditAuthor(EditAuthorDto editAuthorDto);
        Task<ResponseModel<List<Author>>> RemoveAuthor(int idAuthor);
    }
}
