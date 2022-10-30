using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Repositories
{
    public interface IPackageRepository
    {
        public List<Package> GetCurrentPackages();
        public List<Package> GetOutgoingPackages();
        public List<Package> GetMovements(string start, string end);
    }
}