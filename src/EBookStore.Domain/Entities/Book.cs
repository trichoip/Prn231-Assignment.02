using System.ComponentModel.DataAnnotations.Schema;

namespace EBookStore.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public double Advance { get; set; }
        public double Royalty { get; set; }
        public double YtdSales { get; set; }
        public string Notes { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int PubId { get; set; }

        [ForeignKey("PubId")]
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
