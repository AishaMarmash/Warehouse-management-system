using AutoMapper;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;
        public PackageService(IPackageRepository repository,IMapper mapper)
        {
            _packageRepository = repository;
            _mapper = mapper;
        }
        public List<Package> GetCurrentPackages()
        {
            return _packageRepository.GetCurrentPackages();
        }
        public List<Package> GetOutgoingPackages()
        {
            return _packageRepository.GetOutgoingPackages();
        }
        public List<CustomerTransPackages> GetMovements(string start, string end)
        {
            return _packageRepository.GetMovements(start, end);
        }
        public void DeleteExpiredPackages()
        {
            _packageRepository.DeleteExpiredPackages();
        }
        public List<CustomerTransPackagesDto> BuildResponse(List<CustomerTransPackages> movements)
        {
            List<CustomerTransPackagesDto> responseList = new();
            foreach (var obj in movements)
            {
                List<PackageResponseDto> responsePackages = new();
                foreach (var package in obj.packages)
                {
                    var mappedPackage = _mapper.Map<PackageResponseDto>(package);
                    responsePackages.Add(mappedPackage);
                }
                var mappedObj = _mapper.Map<CustomerTransPackagesDto>(obj);
                mappedObj.packages = responsePackages;
                responseList.Add(mappedObj);
            }
            return responseList;

        }

    }
}