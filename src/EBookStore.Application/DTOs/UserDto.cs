using EBookStore.Application.Mappings;
using EBookStore.Domain.Entities;
using System.ComponentModel;

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
        public DateTime? HireDate { get; set; }

        [DefaultValue(null)]
        public int? RoleId { get; set; }

        [DefaultValue(null)]
        public int? PubId { get; set; }
    }
}
