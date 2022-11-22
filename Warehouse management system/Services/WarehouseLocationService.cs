using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;

namespace Warehouse_management_system.Services
{
    public class WarehouseLocationService : IWarehouseLocationService
    {
        private readonly IWarehouseLocationRepository _warehouseLocationRepository;
        public WarehouseLocationService(IWarehouseLocationRepository repository)
        {
            _warehouseLocationRepository = repository;
        }
        public List<WarehouseLocation>GetFreeLocations(DateTime date)
        {
            return _warehouseLocationRepository.GetFreeLocations(date);
        }
        public void AddWarehouseLocation(WarehouseLocation warehouseLocation)
        {
            _warehouseLocationRepository.AddWarehouseLocation(warehouseLocation);
        }
        public WarehouseLocation FindWarehouseLocation(int locationNumber)
        {
            return _warehouseLocationRepository.FindWarehouseLocation(locationNumber);
        }
        public void UpdateLocation()
        {
            _warehouseLocationRepository.UpdateLocation();
        }
    }
}