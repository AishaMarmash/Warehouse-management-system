using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Repositories
{
    public interface IPackageRepository
    {
        public List<Package> GetPackages();
        public List<Package> GetMovements(string start, string end);
    }
}