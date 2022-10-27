using Warehouse_management_system.Domain;

namespace Warehouse_management_system.Models
{
    public class Container
    {
        public int Id { get; set; }//pk
        public ContainerType Type { get; set; }
        public string ContainerNumber { get; set; }
        
        public List<Package> Packages { get; set; } //collection navigation property
        public List<Supplier> Suppliers { get; set; }
    }
}