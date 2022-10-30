using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;

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
                var response = _context.WarehouseLocation
                                .Include(a=>a.SchedulingProcesses)
                                .Where(
                                         c => !_context.SchedulingProcesses
                                         .Where(b => (time.CompareTo(b.ExpectedIn) > 0) &&
                                                     (b.ExpectedOut.CompareTo(time) > 0)
                                               )
                                        .Select(b => b.WarehouseLocationId)
                                        .Contains(c.Id)
                                  ).ToList();
            //List<int> warehouseNotFree = _context.SchedulingProcesses
            //                                .Where(x => (time.CompareTo(x.ExpectedIn)>0) && (x.ExpectedOut.CompareTo(time)>0))
            //                                .Select(c => c.WarehouseLocationId).ToList();
            //var response = _context.WarehouseLocation
            //                        .Where(x => !warehouseNotFree.Contains(x.Id))
            //                        .Select(x=>x).ToList();
            return response;
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
