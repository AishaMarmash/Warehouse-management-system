using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel.Container;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Controllers
{
    [Route("api/container")]
    [ApiController]
    public class ContainerController : Controller
    {
        private readonly IContainerService _containerService;
        private readonly IMapper _mapper;
        public ContainerController(IContainerService containerService, IMapper mapper)
        {
            _containerService = containerService;
            _mapper = mapper;
        }
        [HttpGet("{ContainerNumber}")]
        public ActionResult GetContainer(string containerNumber)
        {
            var container = _containerService.GetContainer(containerNumber);
            
            if(container == null)
                return NotFound();
            var response = _containerService.BuildResponse(container);
            return Ok(response);
        }
        [HttpPost]
        public ActionResult AddContainer([FromBody] AddContainerDto ContainerDto)
        {
            var container = _mapper.Map<Container>(ContainerDto);
            _containerService.AddContainer(container);
            return Ok();
        }
    }
}