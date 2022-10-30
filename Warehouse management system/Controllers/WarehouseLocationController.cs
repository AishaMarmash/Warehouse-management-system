using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;

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
            DateTime dt = Convert.ToDateTime(date);
            var locations = _warehouseLocationService.GetFreeLocations(dt);
            if(locations.Count == 0)
                return NotFound("there are no locations available");
            List<WarehouseLocationResponseDto> warehousLocations = new();
            foreach (var location in locations)
            {
                WarehouseLocationResponseDto mappedLocation = _mapper.Map<WarehouseLocationResponseDto>(location);
                warehousLocations.Add(mappedLocation);
            }
            return Ok(warehousLocations);
        }
        [HttpPost]
        public ActionResult AddLocation([FromBody] CreateLocationDto warehouseLocation)
        {
            var Location = _mapper.Map<WarehouseLocation>(warehouseLocation);
            _warehouseLocationService.AddWarehouseLocation(Location);
            return Ok();
        }
        [HttpPut("{locationNumber}")]
        public ActionResult UpdateLocation(int locationNumber, [FromBody] UpdateLocationDto recievedLocation)
        {
            var locationFromRepo = _warehouseLocationService.FindWarehouseLocation(locationNumber);
            var updatedLocation = _mapper.Map(recievedLocation, locationFromRepo);
            _warehouseLocationService.UpdateLocation();
            return Ok();
        }
    }
}