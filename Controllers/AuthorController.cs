using Books.Api.Application.Response;
using Books.Api.Core.Entities;
using Books.Api.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpGet("ListAuthors")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<List<Author>>>> ListAuthor()
        {
            var author = await _authorService.ListAuthors();
            return Ok(author);
        } 
        
        
        [HttpGet("FindAuthorById")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<Author>>> FindAuthorById(int idAutor)
        {
            var author = await _authorService.GetAuthorById(idAutor);
            return Ok(author);
        } 
        
        [HttpGet("FindAuthorByIdBook/{idAutor}")]
        //ActionResult -> pode nos retornar um resultado 200 - 400 - 500 etc..
        public async Task<ActionResult<ResponseModel<Author>>> FindAuthorByIdBook(int idAutor)
        {
            var author = await _authorService.GetAuthorByIdBook(idAutor);
            return Ok(author);
        }
    }
}
