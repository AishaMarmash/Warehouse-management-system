using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;

namespace Warehouse_management_system.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        protected readonly WarehouseContext _context;
        public SupplierRepository(WarehouseContext context)
        {
            _context = context;
        }
        public List<User> GetSuppliers()
        {
            var suppliers = _context.Suppliers
                                    .Include(supplier => supplier.Containers)
                                    .ThenInclude( container => container.Packages)
                                    .ToList();
            List<User> users = suppliers.Cast<User>().ToList();
            return users;
        }
    }
}