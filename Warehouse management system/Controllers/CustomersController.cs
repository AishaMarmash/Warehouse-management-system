using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetCustomers()
        {
            List<Customer> customers = _customerService.GetCustomers();

            if (customers.Count == 0)
                return NoContent();
            List<UserResponseDto> customersList = new(); 
            foreach (var customer in customers)
            {
                UserResponseDto mappedCustomer = _mapper.Map<UserResponseDto>(customer);
                customersList.Add(mappedCustomer);
            }
            return Ok(customersList);
        }
    }
}