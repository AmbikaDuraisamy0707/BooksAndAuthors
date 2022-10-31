using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public decimal Price { get; set; }
        public MLA Mla { get; set; }
        public CMS Cms { get; set; }

        [NotMapped]
        public string MLA_String { get; set; }

        [NotMapped]
        public string CMS_String { get; set; }
    }

}
