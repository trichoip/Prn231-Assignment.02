using EBookStore.Application.Mappings;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.DTOs
{
    public class PublisherDto : IMapFrom<Publisher>
    {
        public int PubId { get; set; }
        public string PublisherName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //public virtual ICollection<BookDto> Books { get; set; }
    }
}
