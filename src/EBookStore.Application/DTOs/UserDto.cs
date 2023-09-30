using EBookStore.Application.Mappings;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.DTOs
{
    public class UserDto : IMapFrom<User>
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public DateTime? HireDate { get; set; }

        public int PubId { get; set; }

        //public virtual PublisherDto Publisher { get; set; }
        //public virtual RoleDto Role { get; set; }
    }
}
