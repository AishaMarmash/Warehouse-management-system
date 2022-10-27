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
            /*var response = (from supplier in _context.Suppliers
                            join package in _context.Packages
                            on supplier.Id equals package.SupplierId
                            select new SupplierVM()
                            {
                                SupplierId = supplier.Id,
                                SupplierName = supplier.FirstName,
                                PackageId = package.Id
                            }).ToList();*/
            var suppliers = _context.Suppliers
                                 .Include(s => s.Packages)
                                 .ToList();
            return suppliers;
        }

    }
}
