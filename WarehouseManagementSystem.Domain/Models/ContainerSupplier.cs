using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Models
{
    public class ContainerSupplier
    {
        public int ContainersId { get; set; }
        public Container Container { get; set; }
        public int SuppliersId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
