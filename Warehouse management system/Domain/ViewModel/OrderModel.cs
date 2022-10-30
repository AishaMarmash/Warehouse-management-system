using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.ViewModel
{
    public class OrderModel
    {
        public UserDto Customer { get; set; }
        public Supplier Supplier { get; set; }
        public string ContainerNumber { get; set; }
        public List<Package> Packages { get; set; }
        /*
         * List of:
         *      public PackageType Type { get; set; }
         *      public string Dimintions { get; set; }
         *      public List<Note>? Notes { get; set; }
         */
        public SchedulingProcess ScheduleProcess { get; set; }
    }
}