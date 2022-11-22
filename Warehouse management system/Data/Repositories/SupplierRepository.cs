using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Models;

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
                                    .Include(s => s.Containers)
                                    .ThenInclude( c =>c.Packages)
                                    .ToList();
            List<User> users = suppliers.Cast<User>().ToList();
            return users;
        }
    }
}
