using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;

namespace Warehouse_management_system.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackagesController : Controller
    {
        private readonly IPackageService _packageService;
        private readonly IMapper _mapper;
        public PackagesController(IPackageService packageService, IMapper mapper)
        {
            _packageService = packageService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetPackages()
        {
            var packages = _packageService.GetPackages();
            var response = _mapper.Map<List<PackageResponseDto>>(packages);
            if (response.Count == 0)
                return NoContent();
            else
                return Ok(response);
        }

        [HttpGet("movements/{startDate}/{endDate}")]
        public ActionResult GetMovements(string startDate, string endDate)
        {
            var customers = _packageService.GetMovements(startDate, endDate);
            var response = _mapper.Map<List<MovementsDto>>(customers);
            return Ok(response);
        }
    } 
}









        //uncompleted service
        //[HttpPost]
        //public ActionResult AddOrder([FromBody]OrderModel orderModel)
        //{
        //    var customer = _mapper.Map<UserDto>(orderModel.Customer);
        //    var supplier = _mapper.Map<UserDto>(orderModel.Supplier);
        //    _packageService.AddOrder(customer, supplier, packages);
        //    //return Ok();
        //}
    

/*
 * {
 *      customer : {
 *                    
 *                  },
 *      supplier : {
 *                      
 *                  },
 *      containerNumber : ,
 *      packages:[
 *                  {
 *                  },
 *                  {
 *                  }
 *      ],
 *      ScheduleProcess : {
 *                          
 *                        }
 * }
 * 
 */