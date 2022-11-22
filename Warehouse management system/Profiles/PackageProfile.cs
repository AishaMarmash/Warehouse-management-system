﻿using AutoMapper;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageDto>()
                .ForMember(dest => dest.PackageId,
                 opt => opt.MapFrom(src => src.Id));
            CreateMap<CustomerTransPackages, CustomerTransPackagesDto>();
        }
    }
}
