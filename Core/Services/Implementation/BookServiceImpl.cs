using Books.Api.Application.DTOs.AuthorDto;
using Books.Api.Application.DTOs.Book;
using Books.Api.Application.Response;
using Books.Api.Core.Entities;
using Books.Api.Core.Services.Interface;
using Books.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Core.Services.Implementation
{
    public class BookServiceImpl : IBookService
    {

        private readonly ApplicationContext _applicationContext;

        public BookServiceImpl(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<ResponseModel<List<Book>>> CreateBook(CreateBookDto createBookDto)
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {                
              //Qual autor e respectivo a esse livro (pois para criar um novo livro a gente precisa pegar o autor para o qual a gente quer criar o livro, pois pra cria o livro eu preciso que o autor exista)

                //Verificando se existe o autor que eu quero criar esse livro
                var author = await _applicationContext.Author.FirstOrDefaultAsync(x => x.Id == createBookDto.Author.Id);

                if(author is null)
                {
                    response.Message = "Nenhum registro de autor localizado";
                    return response;
                }

                //se o autor existir
                var book = new Book()
                {
                    Title = createBookDto.Title,
                    Author = author
                };

                _applicationContext.Add(book);
                await _applicationContext.SaveChangesAsync();

                response.Data = await _applicationContext.Books.Include(x => x.Author).ToListAsync();
                response.Message = "Livro criado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }

        public async Task<ResponseModel<List<Book>>> EditBook(EditBookDto editBookDto)
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {
                //Pegando o id do livro que ta vindo por parametro e incluindo os autores
                var book = await _applicationContext.Books.Include(x => x.Author).FirstOrDefaultAsync(b => b.Id == editBookDto.Id);

                //podemos editar o autor
                var autor = await _applicationContext.Author.FirstOrDefaultAsync(a => a.Id == editBookDto.Author.Id);

                if(autor is null)
                {
                    response.Message = "Nenhum registro de autor localizado";
                    return response;
                }  
                if(book is null)
                {
                    response.Message = "Nenhum registro de livro localizado";
                    return response;
                }

                book.Title = editBookDto.Title;
                book.Author = autor;

                _applicationContext.Books.Update(book);
                await _applicationContext.SaveChangesAsync();

                response.Data = await _applicationContext.Books.ToListAsync();
                response.Message = "Livro editado com sucesso";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }

        public async Task<ResponseModel<Book>> GetBookById(int idBook)
        {
            ResponseModel<Book> response = new ResponseModel<Book>();
            try
            {
                //FirstOrDefaultAsync o primeiro ou o que atendera condicao
                //authorBanco => authorBanco.Id == idAuthor -> verifico linha por linha no banco ate achar a que condiz com o `idAuthor`
                var book = await _applicationContext.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == idBook);

                if (book is null)
                {
                    response.Message = "Nenhum livro localizado";
                    return response;
                }

                response.Data = book;
                response.Message = "Livro encontrado";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }

        public async Task<ResponseModel<List<Book>>> GetBookByIdAuthor(int idAutor)
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {
               //Dentro da propria tabela de livro eu ja tenho o id do author
               var book = await _applicationContext.Books.Include(x => x.Author).Where(b => b.Author.Id == idAutor).ToListAsync(); //toList pois eu posso ter varios livros para um autor

                if (book is null)
                {
                    response.Message = "Nenhum registro localizado";
                    return response;
                }

                response.Data = book;
                response.Message = "Livro localizado!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }

        public async Task<ResponseModel<List<Book>>> ListBooks()
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {                
                var book = await _applicationContext.Books.Include(x => x.Author).ToListAsync(); //Se nao dou um include no author o author fica nulo

                response.Data = book;
                response.Message = "Lista de livros coletados!";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }

        public async Task<ResponseModel<List<Book>>> RemoveBook(int idBook)
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {
                var book = await _applicationContext.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == idBook); //Vou percorrer o banco e achar o id que esta sendo passado no parametro

                if (book is null)
                {
                    response.Message = "Nenhum livro localizado";
                    return response;
                }

                _applicationContext.Remove(book);
                await _applicationContext.SaveChangesAsync();

                //atualizo a lista
                response.Data = await _applicationContext.Books.ToListAsync();
                response.Message = "Livro removido com sucesso";
                return response; 
            }
            catch (Exception ex)
            {
                response.Message = ex.Message; //-> Esta no responseModel
                response.Status = false; //-> Esta no responseModel (se der false e que deu erro)
                return response;
            }
        }
    }
}
