using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface ISupplierService
    {
        public List<Supplier> GetSuppliers();
    }
}