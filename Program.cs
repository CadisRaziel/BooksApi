using Books.Api.Core.Services.Implementation;
using Books.Api.Core.Services.Interface;
using Books.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecao de dependencia
builder.Services.AddScoped<IAuthorService, AuthorServiceImpl>();
builder.Services.AddScoped<IBookService, BookServiceImpl>();

//Conexao com o banco
builder.Services.AddSqlServer<ApplicationContext>(builder.Configuration["ConnectionStrings:StoreBookCs"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
