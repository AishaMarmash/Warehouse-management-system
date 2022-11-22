using AutoMapper;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;

namespace Warehouse_management_system.Services
{
    public class WarehouseLocationService : IWarehouseLocationService
    {
        private readonly IWarehouseLocationRepository _warehouseLocationRepository;
        private readonly IMapper _mapper;
        public WarehouseLocationService(IWarehouseLocationRepository repository, IMapper mapper)
        {
            _warehouseLocationRepository = repository;
            _mapper = mapper;
        }
        public List<WarehouseLocation> GetFreeLocations(DateTime date)
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
        public List<GetLocationDto> BuildResponse(List<WarehouseLocation> locations)
        {
            List<GetLocationDto> response = _mapper.Map<List<GetLocationDto>>(locations);
            return response;
        }
    }
}