using AutoMapper;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class CustomerService : UserService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository repository , IMapper mapper) : base(mapper)
        {
            _customerRepository = repository;
        }
        public List<User> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
    }
}