using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IContainerRepository _containerRepository;
        public ContainerService(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }
        public Container GetContainer(string containerNumber)
        {
            return _containerRepository.GetContainer(containerNumber);
        }
        public void AddContainer(Container ContainerDto)
        {
            _containerRepository.AddContainer(ContainerDto);
        }
    }
}