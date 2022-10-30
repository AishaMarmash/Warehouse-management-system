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
        public List<Package> GetCurrentPackages()
        {
            var packages = _context.Packages
                                   .Include(p => p.ScheduleProcess)
                                   .Where(p => p.ScheduleProcess.ActualIn != null && 
                                               p.ScheduleProcess.ActualOut == null)
                                   .ToList();
            return packages;
        }
        public List<Package> GetOutgoingPackages()
        {
            var packages = _context.Packages
                                   .Include(p => p.ScheduleProcess)
                                   .Where(p => p.ScheduleProcess.ActualIn != null && 
                                               p.ScheduleProcess.ActualOut != null)
                                   .ToList();
            return packages;
        }
        public List<Package> GetMovements(string start, string end)
        {
            DateTime startDateTime = Convert.ToDateTime(start);
            DateTime endDateTime = Convert.ToDateTime(end);
            var packages = _context.Packages
                            .Include(p => p.ScheduleProcess)
                            .Include(c => c.Customer)
                            .ThenInclude(c=>c.Packages)
                            .Where(
                                    s => (s.ScheduleProcess.ActualIn > startDateTime &&
                                          s.ScheduleProcess.ActualIn < endDateTime) ||
                                         (s.ScheduleProcess.ActualOut > startDateTime &&
                                          s.ScheduleProcess.ActualOut < endDateTime)
                                          )
                                          .Select(m => m).ToList();
            return packages;
        }
    }
}