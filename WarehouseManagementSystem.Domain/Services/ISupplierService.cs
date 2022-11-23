using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface ISupplierService : IUserService
    {
        public List<User> GetSuppliers();
    }
}