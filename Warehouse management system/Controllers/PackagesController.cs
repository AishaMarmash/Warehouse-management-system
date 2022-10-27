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
        public PackagesController(IPackageService packageService,IMapper mapper)
        {
            _packageService = packageService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetPackages()
        {
            var packages = _packageService.GetPackages();
            var response = _mapper.Map<List<PackageResponseDto>>(packages);
            return Ok(response);
        }
    }
}