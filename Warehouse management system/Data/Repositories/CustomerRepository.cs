using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly WarehouseContext _context;
        public CustomerRepository(WarehouseContext context)
        {
            _context = context;
        }
        public List<Customer> GetCustomers()
        {
            /*var r = (from customer in _context.Customers
                            join package in _context.Packages
                            on customer.Id equals package.CustomerId
                            select new CustomerVM()
                            {
                                CustomerId = customer.Id,
                                CustomerName = customer.FirstName,
                                PackageId = package.Id
                            }).ToList();*/
            var customers = _context.Customers
                                 .Include(c => c.Packages)
                                 .ToList();
            return customers;
        }

    }
}
