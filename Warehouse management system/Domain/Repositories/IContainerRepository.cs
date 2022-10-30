using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Repositories
{
    public interface IContainerRepository
    {
        public Container GetContainer(string ContainerNumber);
        public void AddContainer(Container container);
    }
}