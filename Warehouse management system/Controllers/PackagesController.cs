using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse_management_system.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackagesController : Controller
    {
        [HttpGet]
        public ActionResult GetPackages()
        {

            return Ok();
        }
    }
}
