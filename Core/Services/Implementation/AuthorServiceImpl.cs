using Books.Api.Application.Response;
using Books.Api.Core.Entities;
using Books.Api.Core.Services.Interface;
using Books.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Core.Services.Implementation
{
    public class AuthorServiceImpl : IAuthorService
    {
        private readonly ApplicationContext _applicationContext;

        public AuthorServiceImpl(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<ResponseModel<Author>> GetAuthorById(int idAuthor)
        {
            ResponseModel<Author> response = new ResponseModel<Author>();
            try
            {
                //FirstOrDefaultAsync o primeiro ou o que atendera condicao
                //authorBanco => authorBanco.Id == idAuthor -> verifico linha por linha no banco ate achar a que condiz com o `idAuthor`
                var author = await _applicationContext.Author.FirstOrDefaultAsync(authorBanco => authorBanco.Id == idAuthor);

                if(author is null)
                {
                    response.Message = "Nenhum autor localizado";
                    return response;
                }

                response.Data = author;
                response.Message = "Autor encontrado";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }

        public async Task<ResponseModel<Author>> GetAuthorByIdBook(int idBook)
        {
            ResponseModel<Author> response = new ResponseModel<Author>();
            try
            {
                //Include -> esta entrando dentro do Author(model) e pegando as propriedades do Author
                var book = await _applicationContext.Books
                    .Include(author => author.Author)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idBook); //-> Passo em cada id do banco para pegar o id que esta vindo no parametro

                if(book is null)
                {
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                response.Data = book.Author;
                response.Message = "Autor localizado!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }

        public async Task<ResponseModel<List<Author>>> ListAuthors()
        {

            ResponseModel<List<Author>> response = new ResponseModel<List<Author>>();    
            try
            {
                //uso o await e toListAsync para que independente se acha 1 ou 10000 authores eu AGUARDO toda a verificacao para por dentro da variavel `authors`
                var authors = await _applicationContext.Author.ToListAsync(); //-> Entrei na tabela no banco e trasnformei em lista tudo que tem la

                response.Data = authors;
                response.Message = "Lista de autores coletados!";

                return response;

            }
            catch (Exception ex) {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }
    }
}
