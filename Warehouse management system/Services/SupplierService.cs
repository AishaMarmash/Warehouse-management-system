using AutoMapper;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class SupplierService : UserService, ISupplierService
    {
        private readonly ISupplierRepository _suppliersRepository;
        public SupplierService(ISupplierRepository repository, IMapper mapper) : base(mapper)
        {
            _suppliersRepository = repository;
        }
        public List<User> GetSuppliers()
        {
            return _suppliersRepository.GetSuppliers();
        }
    }
}