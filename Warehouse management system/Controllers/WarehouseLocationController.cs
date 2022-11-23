using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel.Location;

namespace Warehouse_management_system.Controllers
{
    [Route("api/warehouseLocations")]
    [ApiController]
    public class WarehouseLocationController : ControllerBase
    {
        private readonly IWarehouseLocationService _warehouseLocationService;
        private readonly IMapper _mapper;
        public WarehouseLocationController(IWarehouseLocationService warehouseLocationService, IMapper mapper)
        {
            _warehouseLocationService = warehouseLocationService;
            _mapper = mapper;
        }
        [HttpGet("{date}")]
        public ActionResult GetFreeLocations(string date)
        {
            //date format YYYY-MM-DD
            try
            {
                var freeLocations = _warehouseLocationService.GetFreeLocations(Convert.ToDateTime(date));
                var response = _warehouseLocationService.BuildResponse(freeLocations);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound("There are no locations available");
            }
        }
        [HttpPost]
        public ActionResult AddLocation([FromBody] CreateLocationDto warehouseLocation)
        {
            var Location = _mapper.Map<WarehouseLocation>(warehouseLocation);
            _warehouseLocationService.AddWarehouseLocation(Location);
            return Ok();
        }
        [HttpPut("{locationNumber}")]
        public ActionResult UpdateLocation(int locationNumber, [FromBody] UpdateLocationDto newLocation)
        {
            var locationFromRepo = _warehouseLocationService.FindWarehouseLocation(locationNumber);
            _warehouseLocationService.UpdateLocation(newLocation, locationFromRepo);
            return Ok();
        }
    }
}