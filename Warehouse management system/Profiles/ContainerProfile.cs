using AutoMapper;
using Warehouse_management_system.Domain;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;
using Warehouse_management_system.Services;

namespace Warehouse_management_system.Profiles
{
    public class ContainerProfile : Profile
    {
        public ContainerProfile()
        {
            CreateMap<Container, GetContainerDto>()
                     .ForMember(dest => dest.Type,
                      opt => opt.MapFrom(src => ((ContainerType)src.Type).GetEnumDescription()));
            CreateMap<GetContainerDto, Container>();
            CreateMap<AddContainerDto, Container>();
        }
    }
}
