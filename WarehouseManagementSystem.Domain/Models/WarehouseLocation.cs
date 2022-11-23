namespace Warehouse_management_system.Domain.Models
{
    public class WarehouseLocation
    {
        public int Id { get; set; }
        public String Dimintion { get; set; }
        public int Capacity { get; set; }
        public List<SchedulingProcess> SchedulingProcesses { get; set; }
    }
}