using Books.Api.Application.DTOs.AuthorDto;
using Books.Api.Application.DTOs.Book;
using Books.Api.Application.Response;
using Books.Api.Core.Entities;
using Books.Api.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("ListBooks")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<List<Book>>>> ListBooks()
        {
            var book = await _bookService.ListBooks();
            return Ok(book);
        }


        [HttpGet("FindBookById/{idBook}")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<Book>>> FindBookById(int idBook)
        { 
            var book = await _bookService.GetBookById(idBook);
            return Ok(book);
        }

        [HttpGet("FindBookByIdAuthor/{idAutor}")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<List<Book>>>> FindBookByIdAuthor(int idAutor)
        {
            var book = await _bookService.GetBookByIdAuthor(idAutor);
            return Ok(book);
        }

        [HttpPost("CreateBook")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<List<Book>>>> CreateBook(CreateBookDto createBookDto) //-> Passo o DTO aqui
        {
            var book = await _bookService.CreateBook(createBookDto);
            return Ok(book);
        }

        [HttpPut("EditBook")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<List<Book>>>> EditBook(EditBookDto editAuthorDto) //-> Passo o DTO aqui
        {
            var book = await _bookService.EditBook(editAuthorDto);
            return Ok(book);
        }

        [HttpDelete("RemoveBook")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<List<Book>>>> RemoveBook(int idBook)
        {
            var book = await _bookService.RemoveBook(idBook);
            return Ok(book);
        }
    }
}
