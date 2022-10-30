using AutoMapper;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<UserDto, Customer>();
            CreateMap<UserDto, Supplier>();
            CreateMap<Supplier, SupplierResponseDto>();
        }
    }
}