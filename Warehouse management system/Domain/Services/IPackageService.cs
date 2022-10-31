using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface IPackageService
    {
        public List<Package> GetCurrentPackages();
        public List<Package> GetOutgoingPackages();
        public List<CustomerTransPackages> GetMovements(string start, string end);
        public void DeleteExpiredPackages();
        public List<CustomerTransPackagesDto> BuildResponse(List<CustomerTransPackages> movements);
    }
}