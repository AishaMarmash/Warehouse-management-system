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
        public List<WarehouseLocation> GetFreeLocations(DateTime time)
        {
            List<int> warehouseNotFree = _context.SchedulingProcesses
                                                 .Where(x => (time.CompareTo(x.ExpectedIn)>0) && (x.ExpectedOut.CompareTo(time)>0))
                                                 .Select(c => c.WarehouseLocationId).ToList();
            var freeWarehouses = _context.WarehouseLocation
                                   .Where(x => !warehouseNotFree.Contains(x.Id))
                                   .Select(x=>x).ToList();
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
            var location = _context.WarehouseLocation.First(l => l.Id == locationNumber);
            return location;
        }
        public void UpdateLocation()
        {
            _context.SaveChanges(); ;
        }
    }
}
