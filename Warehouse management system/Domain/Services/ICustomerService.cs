using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface ICustomerService : IUserService
    {
        public List<User> GetCustomers();
    }
}