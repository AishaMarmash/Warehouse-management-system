using Microsoft.EntityFrameworkCore;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Models;
using Container = Warehouse_management_system.Models.Container;

namespace Warehouse_management_system.Data
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer(@"Data Source=DESKTOP-G3U2PSS; Initial Catalog = WMS; Integrated Security = True");
        }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SchedulingProcess> SchedulingProcesses { get; set; }
        public DbSet<ContainerSupplier> ContainerSupplier { get; set; }
        public DbSet<WarehouseLocation> WarehouseLocation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Container>()
                .HasMany(c => c.Packages)
                .WithOne(p => p.Container);

            builder
                .Entity<Package>()
                .HasMany(p => p.Notes)
                .WithMany(n => n.Packages);
            
            builder
                .Entity<Supplier>()
                .HasMany(s => s.Containers)
                .WithMany(c => c.Suppliers);

            builder
                .Entity<WarehouseLocation>()
                .HasMany(l => l.SchedulingProcesses)
                .WithOne(s => s.Location);

            builder
                .Entity<Customer>()
                .HasMany(c => c.Packages)
                .WithOne(p => p.Customer);

            builder
                .Entity<SchedulingProcess>()
                .HasMany(s => s.Packages)
                .WithOne(p => p.ScheduleProcess);

            builder
                .Entity<Supplier>()
                .HasMany(s => s.Containers)
                .WithMany(c => c.Suppliers)
                .UsingEntity<ContainerSupplier>(
                j => j.HasKey(p => new { p.SuppliersId, p.ContainersId }));
        }
    }
}
