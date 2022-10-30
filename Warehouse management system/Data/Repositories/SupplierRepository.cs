using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.ViewModel;
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
        public List<Supplier> GetSuppliers()
        {
            var suppliers = _context.Suppliers
                                 .Include(s => s.Packages)
                                 .ToList();
            return suppliers;
        }
    }
}
