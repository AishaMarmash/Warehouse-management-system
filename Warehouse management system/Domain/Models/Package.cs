using Warehouse_management_system.Domain;
using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Models
{
    public class Package
    {
        public int Id { get; set; } 
        public bool? IsExpired { get; set; }
        public bool? IsOut { get; set; }
        public PackageType Type { get; set; }
        public string Dimintions { get; set; }
        public int ContainerId { get; set; }
        public Container Container { get; set; }
        public List<Note>? Notes { get; set; }
        public int ScheduleProcessId { get; set; }
        public SchedulingProcess ScheduleProcess { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}