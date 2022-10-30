using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Repositories;
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
            var customers = _context.Customers
                                 .Include(c => c.Packages)
                                 .ToList();
            return customers;
        }
    }
}