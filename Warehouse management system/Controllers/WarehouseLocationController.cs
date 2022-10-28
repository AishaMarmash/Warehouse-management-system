using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Controllers
{
    [Route("api/warehouseLocation")]
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
            List<WarehouseLocationResponseDto> warehousLocations = new();
            foreach (var location in locations)
            {
                WarehouseLocationResponseDto mappedLocation = _mapper.Map<WarehouseLocationResponseDto>(location);
                warehousLocations.Add(mappedLocation);
            }
            return Ok(warehousLocations);
        }
    }
}
