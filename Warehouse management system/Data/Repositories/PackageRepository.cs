using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.ViewModel;
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
        public List<CustomerTransPackages> GetMovements(string start, string end)
        {
            DateTime startDateTime = Convert.ToDateTime(start);
            DateTime endDateTime = Convert.ToDateTime(end);
            var customerTransPackages = _context.Customers
                                        .Select(u => new CustomerTransPackages()
                                                         {
                                                            CustomerId = u.Id,
                                                            CustomerName = u.FirstName + " " + u.MiddleName+ " " + u.LastName,
                                                            packages = u.Packages.Where(p => (p.ScheduleProcess.ActualIn > startDateTime &&
                                                                                              p.ScheduleProcess.ActualIn < endDateTime)||
                                                                                             (p.ScheduleProcess.ActualOut > startDateTime &&
                                                                                              p.ScheduleProcess.ActualOut < endDateTime))
                                                                                 .ToList()
                                                         })
                                        .Where(u=>u.packages.Count > 0)
                                        .ToList();
            return customerTransPackages;
        }
        public void DeleteExpiredPackages()
        {
            var packages = _context.Packages
                                   .Include(p => p.ScheduleProcess)
                                   .Where(p => (p.ScheduleProcess.ActualIn == null && 
                                                p.ScheduleProcess.ExpectedIn.AddDays(+3) < DateTime.Now))
                                   .ToList();
            _context.Packages.RemoveRange(packages);
            _context.SaveChanges();
        }
    }
}