using AutoMapper;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
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
        public List<PackageDto> BuildNormalPackageResponse(List<Package> packages)
        {
            var response = _mapper.Map<List<PackageDto>>(packages);
            return response;
        }
        public List<CustomerTransPackagesDto> BuildTransferredPackagesResponse(List<CustomerTransPackages> movements)
        {
            List<CustomerTransPackagesDto> responseList = new();
            foreach (var movement in movements)
            {
                List<PackageDto> responsePackages = new();
                foreach (var package in movement.packages)
                {
                    var mappedPackage = _mapper.Map<PackageDto>(package);
                    responsePackages.Add(mappedPackage);
                }
                var mappedMovement = _mapper.Map<CustomerTransPackagesDto>(movement);
                mappedMovement.packages = responsePackages;
                responseList.Add(mappedMovement);
            }
            return responseList;
        }
    }
}