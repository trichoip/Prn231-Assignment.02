using EBookStore.Application.Mappings;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.DTOs
{
    public class BookAuthorDto : IMapFrom<BookAuthor>
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public int AuthorOrder { get; set; }
        public float RoyalityPercentage { get; set; }
        //public virtual AuthorDto Author { get; set; }
        //public virtual BookDto Book { get; set; }
    }
}
