using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetSuppliers()
        {
            List<Supplier> suppliers = _supplierService.GetSuppliers();
            if (suppliers.Count == 0)
                return NoContent();
            List<SupplierResponseDto> suppliersList = new();
            foreach (var supplier in suppliers)
            {
                SupplierResponseDto mappedSupplier = _mapper.Map<SupplierResponseDto>(supplier);
                suppliersList.Add(mappedSupplier);
            }
            return Ok(suppliersList);
        }
    }
}
