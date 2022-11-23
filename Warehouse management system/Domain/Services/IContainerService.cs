using Warehouse_management_system.Domain.ViewModel.Container;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface IContainerService
    {
        public Container? GetContainer(string containerNumber);
        public void AddContainer(Container container);
        public GetContainerDto BuildResponse(Container container);
    }
}