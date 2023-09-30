using EBookStore.Application.Mappings;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.DTOs
{
    public class BookDto : IMapFrom<Book>
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

        //public virtual PublisherDto Publisher { get; set; }
        //public virtual ICollection<BookAuthorDto> BookAuthors { get; set; }
    }
}
