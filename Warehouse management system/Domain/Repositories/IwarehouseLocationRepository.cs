using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Domain.Repositories
{
    public interface IWarehouseLocationRepository
    {
        public List<WarehouseLocation> GetFreeLocations(DateTime time);
        public void AddWarehouseLocation(WarehouseLocation warehouseLocation);
        public WarehouseLocation FindWarehouseLocation(int locationNumber);
        public void UpdateLocation();
    }
}