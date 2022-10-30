using AutoMapper;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageResponseDto>()
                .ForMember(dest => dest.PackageId,
                 opt => opt.MapFrom(src => src.Id));
            CreateMap<Package, MovementsDto>();
        }
    }
}
