using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.ViewModel.Packages
{
    public class CustomerTransferredPackagesDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<PackageDto> packages { get; set; }
    }
}