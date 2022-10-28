using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface IWarehouseLocationService
    {
        public List<WarehouseLocation> GetFreeLocations(DateTime time);
    }
}
