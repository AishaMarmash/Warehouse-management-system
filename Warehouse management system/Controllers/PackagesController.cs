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
        [HttpGet("current")]
        public ActionResult GetCurrentPackages()
        {
            var packages = _packageService.GetCurrentPackages();
            var response = _mapper.Map<List<PackageResponseDto>>(packages);
            if (response.Count == 0)
                return NoContent();
            else
                return Ok(response);
        }
        [HttpGet("outgoing")]
        public ActionResult GetOutgoingPackages()
        {
            var packages = _packageService.GetOutgoingPackages();
            var response = _mapper.Map<List<PackageResponseDto>>(packages);
            if (response.Count == 0)
                return NoContent();
            else
                return Ok(response);
        }
        [HttpGet("movements/{startDate}/{endDate}")]
        public ActionResult GetMovements(string startDate, string endDate)
        {
            var movements = _packageService.GetMovements(startDate, endDate);
            var responseList = _packageService.BuildGroupedResponse(movements);
            return Ok(responseList);
        }
        [HttpDelete("expired")]
        public ActionResult DeleteExpiredPackages()
        {
            _packageService.DeleteExpiredPackages();
            return Ok("Checked and deleted the expired packages if any found");
        }
    } 
}