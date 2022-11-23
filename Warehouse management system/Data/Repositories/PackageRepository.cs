using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.ViewModel.Packages;
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
                                   .Include(package => package.ScheduleProcess)
                                   .Where(package => package.ScheduleProcess.ActualIn != null &&
                                                     package.ScheduleProcess.ActualOut == null)
                                   .ToList();
            return packages;
        }
        public List<Package> GetOutgoingPackages()
        {
            var packages = _context.Packages
                                   .Include(package => package.ScheduleProcess)
                                   .Where(package => package.ScheduleProcess.ActualIn != null &&
                                                     package.ScheduleProcess.ActualOut != null)
                                   .ToList();
            return packages;
        }
        public List<CustomerTransferredPackages> GetMovements(string start, string end)
        {
            DateTime startDateTime = Convert.ToDateTime(start);
            DateTime endDateTime = Convert.ToDateTime(end);
            var customerTransPackages = _context.Customers
                                        .Select(customer => new CustomerTransferredPackages()
                                                         {
                                                            CustomerId = customer.Id,
                                                            CustomerName = customer.FirstName + " " + customer.MiddleName+ " " + customer.LastName,
                                                            packages = customer.Packages.Where(package => (package.ScheduleProcess.ActualIn > startDateTime &&
                                                                                                           package.ScheduleProcess.ActualIn < endDateTime)||
                                                                                                          (package.ScheduleProcess.ActualOut > startDateTime &&
                                                                                                           package.ScheduleProcess.ActualOut < endDateTime))
                                                                                        .ToList()
                                                         })
                                        .Where(customer => customer.packages.Count > 0)
                                        .ToList();
            return customerTransPackages;
        }
        public void DeleteExpiredPackages()
        {
            var packages = _context.Packages
                                   .Include(package => package.ScheduleProcess)
                                   .Where(package => (package.ScheduleProcess.ActualIn == null &&
                                                      package.ScheduleProcess.ExpectedIn.AddDays(+3) < DateTime.Now))
                                   .ToList();
            _context.Packages.RemoveRange(packages);
            _context.SaveChanges();
        }
    }
}