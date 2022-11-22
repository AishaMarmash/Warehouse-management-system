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
            CreateMap<WarehouseLocation, GetLocationDto>();
            CreateMap<CreateLocationDto, WarehouseLocation>();
            CreateMap<UpdateLocationDto, WarehouseLocation>()
            .ForMember(dest => dest.Capacity,
                        opt => opt.Condition((src, dest, srcMember) => srcMember != 0))
            .ForMember(dest => dest.Dimintion,
                        opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}