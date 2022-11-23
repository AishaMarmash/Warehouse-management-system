using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Data.Repositories
{
    public class ContainerRepository : IContainerRepository
    {
        protected readonly WarehouseContext _context;
        public ContainerRepository(WarehouseContext context)
        {
            _context = context;
        }
        public Container? GetContainer(string containerNumber)
        {
            return _context.Containers.FirstOrDefault(container => container.ContainerNumber.Equals(containerNumber));
        }
        public void AddContainer(Container container)
        {
            _context.Containers.Add(container);
            _context.SaveChanges();
        }
    }
}