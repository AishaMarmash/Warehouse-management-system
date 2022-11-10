using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;
using Warehouse_management_system.Services;

namespace Warehouse_management_system.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Customer, UserResponseDto>();
            CreateMap<UserDto, Customer>();
            CreateMap<UserDto, Supplier>();
            CreateMap<Supplier, UserResponseDto>()
                .ForMember(dest => dest.Packages,
                 opt => opt.MapFrom(src => src.Containers.GetPackages()));
        }
    }
}