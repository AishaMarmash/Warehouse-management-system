namespace Warehouse_management_system.Data.Repositories
{
    public class WarehouseLocationRepository
    {
        protected readonly WarehouseContext _context;
        public WarehouseLocationRepository(WarehouseContext context)
        {
            _context = context;
        }
        public void GetFreeLocations(DateTime time)
        {
            
        }

    }
}
