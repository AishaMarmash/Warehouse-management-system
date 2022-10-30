using AutoMapper;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Profiles
{
    public class ContainerProfile : Profile
    {
        public ContainerProfile()
        {
            CreateMap<Container, ContainerDto>();
            CreateMap<ContainerDto,Container>();
        }
    }
}
