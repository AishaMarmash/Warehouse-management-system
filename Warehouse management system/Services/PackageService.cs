using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        public PackageService(IPackageRepository repository)
        {
            _packageRepository = repository;
        }
        public List<Package> GetPackages()
        {
            return _packageRepository.GetPackages();
        }
    }
}