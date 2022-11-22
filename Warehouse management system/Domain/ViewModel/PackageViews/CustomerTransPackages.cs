using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Models
{
    public class CustomerTransPackages
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<Package> packages { get; set; }
    }
}
