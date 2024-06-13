using Books.Api.Application.DTOs.Links;
using Books.Api.Core.Entities;

namespace Books.Api.Application.DTOs.Book
{
    public record EditBookDto(int Id, String Title, AuthorLinkDto Author)
    {
    }
}
