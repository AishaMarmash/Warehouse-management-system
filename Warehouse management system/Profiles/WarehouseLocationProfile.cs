using AutoMapper;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Profiles
{
    public class WarehouseLocationProfile : Profile
    {
        public WarehouseLocationProfile()
        {
            CreateMap<WarehouseLocation, WarehouseLocationResponseDto>();
        }
    }
}
