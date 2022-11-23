using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;

namespace Warehouse_management_system.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly WarehouseContext _context;
        public CustomerRepository(WarehouseContext context)
        {
            _context = context;
        }
        public List<User> GetCustomers()
        {
            var customers = _context.Customers
                                    .Include(customer => customer.Packages)
                                    .ToList();
            List<User> users = customers.Cast<User>().ToList();
            return users;
        }
    }
}