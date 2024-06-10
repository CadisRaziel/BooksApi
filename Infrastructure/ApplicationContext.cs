using Books.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Books.Api.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
