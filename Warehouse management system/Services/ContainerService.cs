using AutoMapper;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel.Container;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IContainerRepository _containerRepository;
        private readonly IMapper _mapper;
        public ContainerService(IContainerRepository containerRepository,IMapper mapper)
        {
            _containerRepository = containerRepository;
            _mapper = mapper;
        }
        public Container? GetContainer(string containerNumber)
        {
            return _containerRepository.GetContainer(containerNumber);
        }
        public void AddContainer(Container ContainerDto)
        {
            _containerRepository.AddContainer(ContainerDto);
        }

        public GetContainerDto BuildResponse(Container container)
        {
            var response = _mapper.Map<GetContainerDto>(container);
            return response;
        }
    }
}