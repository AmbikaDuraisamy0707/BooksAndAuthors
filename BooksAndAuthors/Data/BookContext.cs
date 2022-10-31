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

        //public DbSet<BookPublisher> BookPublisher { get; set; }
        //public DbSet<BookAuthor> BookAuthor { get; set; }

        //public DbSet<BookDTO> PublishBook { get; set; }
       // public DbSet<AuthorDTO> Author { get; set; }
        

    }
}
