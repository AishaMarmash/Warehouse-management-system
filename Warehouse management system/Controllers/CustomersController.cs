using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public ActionResult GetCustomers()
        {
            List<User> customers = _customerService.GetCustomers();

            if (customers.Count == 0)
                return NoContent();
            var response = _customerService.BuildResponse(customers);
            return Ok(response);
        }
    }
}