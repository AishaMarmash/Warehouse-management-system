using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Repositories
{
    public interface IPackageRepository
    {
        public List<Package> GetCurrentPackages();
        public List<Package> GetOutgoingPackages();
        public List<CustomerTransPackages> GetMovements(string start, string end);
        public void DeleteExpiredPackages();
    }
}