using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.ViewModel
{
    public class CustomerTransPackagesDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<PackageResponseDto> packages { get; set; }
    }
}
