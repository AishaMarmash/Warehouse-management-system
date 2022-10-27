using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Data.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        protected readonly WarehouseContext _context;
        public PackageRepository(WarehouseContext context)
        {
            _context = context;
        }
        public List<Package> GetPackages()
        {
            var packages = _context.SchedulingProcesses
                                .Include(u => u.Packages)
                                .ThenInclude(u => u.Container)
                                .ThenInclude(c=>c.Suppliers)
                                .Where(s => (s.ActualIn != null && s.ActualOut == null) ||
                                     (s.ActualOut != null) ||
                                     !(s.ActualIn == null && s.ExpectedIn.AddDays(+3) < DateTime.Now))
                                .SelectMany(s=>s.Packages).ToList();
            return packages;                        
        }
    }
}