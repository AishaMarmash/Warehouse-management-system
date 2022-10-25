using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public List<Package> Packages { get; set; }
    }
}
