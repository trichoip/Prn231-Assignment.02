using EBookStore.Application.Mappings;
using EBookStore.Domain.Entities;

namespace EBookStore.Application.DTOs
{
    public class RoleDto : IMapFrom<Role>
    {
        public int RoleId { get; set; }
        public string RoleDesc { get; set; }
    }
}
