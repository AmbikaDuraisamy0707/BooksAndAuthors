using BooksAndAuthors.Data;
using BooksAndAuthors.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BooksAndAuthors.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext;
        public BookRepository(BookContext context)
        {
            _bookContext = context;
        }
   
        public IEnumerable<Book> GetAuthors()
        {

            return _bookContext.Books.AsNoTracking().
               OrderBy(b => b.AuthorFirstName).
               ThenBy(b => b.AuthorLastName).
               ThenBy(b => b.Title);
        }

        public IEnumerable<Book> GetBooks()
        {
            StringBuilder str = new StringBuilder();
            StringBuilder str1 = new StringBuilder();


            var _bookContextVal = _bookContext.Books.Include(b => b.Mla).Include(b => b.Cms).AsNoTracking().
               OrderBy(b => b.Publisher).
               ThenBy(b => b.AuthorFirstName).
               ThenBy(b => b.AuthorLastName).
               ThenBy(b => b.Title);

            var booksToReturn = _bookContextVal.ToList();

            foreach (var book in booksToReturn)
            {
                var item = book;
                

                if (book.Mla != null)
                {
                    str.Append("<html>");
                    str.Append(book.AuthorLastName + book.AuthorFirstName + ".");
                    str.Append($"''" + book.Title + "''.");
                    str.Append("/n");
                    str.Append("<I>" + book.Mla.TitleOfContainer + "</I>" + "," + book.Publisher + "," + book.Mla.PublicationDate + "," + book.Mla.PageRange + ".");
                    str.Append("</html>");
                    book.MLA_String = str.ToString();
                }

                if (book.Cms != null)
                {
                    str1.Append("<html>");
                    str1.Append(book.AuthorLastName + book.AuthorFirstName + "." + $"''" + book.Title + "'',");
                    str1.Append("/n");
                    str1.Append("<I>" + book.Cms.JournalTitle + "</I>" + " " + book.Cms.VolumeNo + ", no" + book.Cms.IssueNo + " (" + book.Cms.Year + "):" + book.Cms.PageRange + "," + book.Cms.Url + "." + book.Cms.DOI);
                    str1.Append("</html>");
                    book.CMS_String = str1.ToString();
                }

            }
            return booksToReturn;
        }


        public IEnumerable<Book> GetBooksByStoredProc()
        {
            return _bookContext.Books.FromSqlRaw<Book>("GetBooks").ToList();
        }

        public IEnumerable<Book> GetAuthorsByStoredProc()
        {
            return _bookContext.Books.FromSqlRaw<Book>("GetAuthors").AsEnumerable();
        }

        public decimal GetTotalPrice()
        {
            return _bookContext.Books?.AsNoTracking().Sum(p => p.Price) ?? 0;
        }


    }
}
