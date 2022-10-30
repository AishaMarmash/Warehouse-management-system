namespace Warehouse_management_system.Domain.ViewModel
{
    public class PackageResponseDto
    {
        public int PackageId { get; set; }
        public bool? IsExpired { get; set; }
        public bool? IsOut { get; set; }
    }
}