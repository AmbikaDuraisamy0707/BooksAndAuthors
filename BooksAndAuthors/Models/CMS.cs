using System.ComponentModel.DataAnnotations;

namespace BooksAndAuthors.Models
{
    public class CMS
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string JournalTitle { get; set; }
        public string IssueNo { get; set; }
        public int VolumeNo { get; set; }
        public int Year { get; set; }
        public string Url { get; set; }
        public string PageRange { get; set; }
        public string DOI { get; set; }

    }
}
