using System.Text.Json.Serialization;

namespace Books.Api.Core.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        //Cada Autor pode ter varios livros
        [JsonIgnore] //-> Ignora a propriedade na hora de serializar
        //Exemplo na hora de criar o author no postman ou qualquer outro lugar eu nao preciso passar a lista de livros em seu nome
        //A propriedade Books e apenas para nos fazermos a relacao, nos iremos criar os livros em outro local
        public ICollection<Book> Books { get; set; }
    }
}
