using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Repositories
{
    public interface ISupplierRepository
    {
        public List<Supplier> GetSuppliers();
    }
}