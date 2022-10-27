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
        //one container has many packages 
        //while package relate to 1 container
        // 1 to many relationship
        public int ContainerId { get; set; }//fk
        public Container Container { get; set; } //reference navigation property
        // 1 package has many notes
        public List<Note>? Notes { get; set; }
        // 1 package has 1 schedule
        // while 1 schedule may have many package to send or recieve in
        public int ScheduleProcessId { get; set; }
        public SchedulingProcess ScheduleProcess { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}