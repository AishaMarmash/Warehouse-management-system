using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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
        public DbSet<SchedulingProcess> SchedulingProcesses { get; set; }

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
        }
    }
}
