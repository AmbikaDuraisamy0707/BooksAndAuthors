using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Models
{
    public class MLA
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string TitleOfContainer { get; set; }
        public string TitleOfSource { get; set; }
        public string PublicationDate { get; set; }
        public string Location { get; set; }
        public string PageRange { get; set; }
    }
}
