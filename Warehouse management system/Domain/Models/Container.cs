using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Models
{
    public class Container
    {
        public int Id { get; set; }
        public ContainerType Type { get; set; }
    }
}