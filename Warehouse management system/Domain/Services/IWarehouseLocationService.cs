using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.ViewModel;

namespace Warehouse_management_system.Domain.Services
{
    public interface IWarehouseLocationService
    {
        public List<WarehouseLocation> GetFreeLocations(DateTime date);
        public void AddWarehouseLocation(WarehouseLocation warehouseLocation);
        public WarehouseLocation FindWarehouseLocation(int locationNumber);
        public void UpdateLocation();
        public List<GetLocationDto> BuildResponse(List<WarehouseLocation> locations);
    }
}