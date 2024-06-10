namespace Books.Api.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        //Um livro pode ter um autor especifico
        public Author Author { get; set; }
    }
}
