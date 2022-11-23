using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Domain.Repositories
{
    public interface ICustomerRepository
    {
        public List<User> GetCustomers();
    }
}