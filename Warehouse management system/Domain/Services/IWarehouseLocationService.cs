using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface IWarehouseLocationService
    {
        public List<WarehouseLocation> GetFreeLocations(DateTime time);
        public void AddWarehouseLocation(WarehouseLocation warehouseLocation);
        public WarehouseLocation FindWarehouseLocation(int locationNumber);
        public void UpdateLocation();
    }
}