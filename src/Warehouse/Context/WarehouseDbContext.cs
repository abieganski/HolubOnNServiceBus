using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Warehouse.Entities;

namespace Warehouse.Context;

public partial class WarehouseDbContext : DbContext, IWarehouseDbContext
{
    private readonly IConfiguration _configuration;

    public WarehouseDbContext()
    {
    }

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Warehouse"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PickList>(entity =>
        {
            entity.HasKey(e => e.PickListId);
            entity.Property(e => e.PickListId).ValueGeneratedOnAdd();
            entity.Property(e => e.OrderId).HasMaxLength(100).IsRequired();
            entity.Property(e => e.IsPicked).HasDefaultValueSql("((0))");
            entity.Property(e => e.RowVersion).IsRowVersion(); // this should be done for all AggregateBase entities
        });

        modelBuilder.Entity<PickListItem>(entity =>
        {
            entity.HasKey(e => e.PickListItemId);
            entity.Property(e => e.PickListItemId).ValueGeneratedOnAdd();
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.Sku).HasMaxLength(100).IsRequired();
        });
    }

    
    
    public DbSet<PickList> PickLists { get; set; }
    public DbSet<PickListItem> PickListItems { get; set; }
}
