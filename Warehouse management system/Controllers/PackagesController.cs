using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Services;

namespace Warehouse_management_system.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackagesController : Controller
    {
        private readonly IPackageService _packageService;
        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }
        [HttpGet("current")]
        public ActionResult GetCurrentPackages()
        {
            var packages = _packageService.GetCurrentPackages();
            if (packages.Count == 0)
                return NoContent();
            var response = _packageService.BuildNormalPackageResponse(packages);
            return Ok(response);
        }
        [HttpGet("outgoing")]
        public ActionResult GetOutgoingPackages()
        {
            var packages = _packageService.GetOutgoingPackages();
            if (packages.Count == 0)
                return NoContent();
            var response = _packageService.BuildNormalPackageResponse(packages);
            return Ok(response);
        }
        [HttpGet("movements/{startDate}/{endDate}")]
        public ActionResult GetMovements(string startDate, string endDate)
        {
            var movements = _packageService.GetMovements(startDate, endDate);
            if (movements.Count == 0)
                return NoContent();
            var response = _packageService.BuildTransferredPackagesResponse(movements);
            return Ok(response);
        }
        [HttpDelete("expired")]
        public ActionResult DeleteExpiredPackages()
        {
            _packageService.DeleteExpiredPackages();
            return Ok("Checked and deleted the expired packages if any found");
        }
    } 
}