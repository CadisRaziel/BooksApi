namespace Books.Api.Application.Response
{
    public class ResponseModel<T> //-> Sera generico para podermos usar tanto para author quanto para books
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty; //-> Inicia com uma string vazia (caso nao coloque nada continura vazia)
        public bool Status { get; set; } = true; //-> Se nao marcar nada no status ele sera true
    }
}
