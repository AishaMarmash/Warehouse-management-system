using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Domain.ViewModel
{
    public class UserDto
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public List<PackageDto> Packages { get; set; } = new();
    }
}