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
            try
            {
                var freeLocations = _warehouseLocationService.GetFreeLocations(Convert.ToDateTime(date));
                List<WarehouseLocationResponseDto> FreewarehousLocations = new();
                foreach (var location in freeLocations)
                {
                    WarehouseLocationResponseDto mappedFreeLocation = _mapper.Map<WarehouseLocationResponseDto>(location);
                    FreewarehousLocations.Add(mappedFreeLocation);
                }
                return Ok(FreewarehousLocations);
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
        public ActionResult UpdateLocation(int locationNumber, [FromBody] UpdateLocationDto recievedLocation)
        {
            var locationFromRepo = _warehouseLocationService.FindWarehouseLocation(locationNumber);
            var updatedLocation = _mapper.Map(recievedLocation, locationFromRepo);
            _warehouseLocationService.UpdateLocation();

            var response = _mapper.Map<WarehouseLocationResponseDto>(updatedLocation);
            return Ok(response);
        }
    }
}