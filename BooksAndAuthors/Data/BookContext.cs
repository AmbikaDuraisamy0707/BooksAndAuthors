using BooksAndAuthors.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAndAuthors.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
            //this.Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

    }
}
