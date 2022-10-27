using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Models
{
    public class SchedulingProcess
    {
        public int Id { get; set; }
        public DateTime? ActualIn { get; set; }
        public DateTime? ActualOut { get; set; }
        public DateTime ExpectedIn { get; set; }
        public DateTime ExpectedOut { get; set; }

        public List<Package> Packages { get; set; } = new();

        public int WarehouseLocationId { get; set; }
        public WarehouseLocation Location { get; set; }
    }
}