using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Domain.ViewModel
{
    public class GetLocationDto
    {
        public int Id { get; set; }
        public String Dimintion { get; set; }
        public int Capacity { get; set; }
    }
}