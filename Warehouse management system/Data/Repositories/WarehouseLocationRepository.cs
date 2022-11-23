using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;

namespace Warehouse_management_system.Data.Repositories
{
    public class WarehouseLocationRepository : IWarehouseLocationRepository
    {
        protected readonly WarehouseContext _context;
        public WarehouseLocationRepository(WarehouseContext context)
        {
            _context = context;
        }
        public List<WarehouseLocation> GetFreeLocations(DateTime date)
        {
            var freeWarehouses = _context.WarehouseLocation
                                         .Include(location => location.SchedulingProcesses)
                                         .Where(
                                                 location => !_context.SchedulingProcesses
                                                                      .Where(schedule => (date > schedule.ExpectedIn && 
                                                                             date < schedule.ExpectedOut))
                                                                      .Select(schedule => schedule.WarehouseLocationId)
                                                                      .Contains(location.Id))
                                         .ToList();
            if (freeWarehouses.Count == 0)
                throw new Exception();
            return freeWarehouses;
        }
        public void AddWarehouseLocation(WarehouseLocation warehouseLocation)
        {
            _context.WarehouseLocation.Add(warehouseLocation);
            _context.SaveChanges();
        }
        public WarehouseLocation FindWarehouseLocation(int locationNumber)
        {
            var location = _context.WarehouseLocation.First(location => location.Id == locationNumber);
            return location;
        }
        public void UpdateLocation()
        {
            _context.SaveChanges();
        }
    }
}
