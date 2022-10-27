using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface IPackageService
    {
        public List<Package> GetPackages();
    }
}
