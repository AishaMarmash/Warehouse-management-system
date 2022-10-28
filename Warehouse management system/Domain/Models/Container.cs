using Warehouse_management_system.Domain;

namespace Warehouse_management_system.Models
{
    public class Container
    {
        public int Id { get; set; }
        public ContainerType Type { get; set; }
        public string ContainerNumber { get; set; }
        
        public List<Package> Packages { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}