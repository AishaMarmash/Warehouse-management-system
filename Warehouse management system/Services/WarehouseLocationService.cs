using Warehouse_management_system.Data.Repositories;
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
        public List<WarehouseLocation>GetFreeLocations(DateTime time)
        {
            return _warehouseLocationRepository.GetFreeLocations(time);
        }
    }
}
