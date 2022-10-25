namespace Warehouse_management_system.Domain.Models
{
    public class SchedulingProcess
    {
        public int Id { get; set; }
        public DateOnly ActualIn { get; set; }
        public DateOnly ActualOut { get; set; }
        public DateOnly ExpectedIn { get; set; }
        public DateOnly ExpectedOut { get; set; }
    }
}