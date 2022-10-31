using BooksAndAuthors.Models;

namespace BooksAndAuthors.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();

        IEnumerable<Book> GetAuthors();

        IEnumerable<Book> GetBooksByStoredProc();

        IEnumerable<Book> GetAuthorsByStoredProc();

        decimal GetTotalPrice();

    }
}
