using Warehouse_management_system.Data.Repositories;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _suppliersRepository;
        public SupplierService(ISupplierRepository repository)
        {
            _suppliersRepository = repository;
        }
        public List<Supplier> GetSuppliers()
        {
            return _suppliersRepository.GetSuppliers();
        }
    }
}
