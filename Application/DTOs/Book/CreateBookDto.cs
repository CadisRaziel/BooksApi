using Books.Api.Application.DTOs.Links;
using Books.Api.Core.Entities;

namespace Books.Api.Application.DTOs.Book
{
    public record CreateBookDto (String Title, AuthorLinkDto Author)
    {
    }
}
