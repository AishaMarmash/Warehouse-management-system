using Warehouse_management_system.Domain.ViewModel.Packages;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface IPackageService
    {
        public List<Package> GetCurrentPackages();
        public List<Package> GetOutgoingPackages();
        public List<CustomerTransferredPackages> GetMovements(string start, string end);
        public void DeleteExpiredPackages();
        public List<PackageDto> BuildNormalPackageResponse(List<Package> packages);
        public List<CustomerTransferredPackagesDto> BuildTransferredPackagesResponse(List<CustomerTransferredPackages> movements);
    }
}