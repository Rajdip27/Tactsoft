using Microsoft.EntityFrameworkCore;
using TIMS.Inventory.Infrastructure.Persistence.Configuration;

namespace TIMS.Inventory.Infrastructure.Persistence;

public class TIMSContext : DbContext
{
    public TIMSContext(DbContextOptions<TIMSContext> options)
        : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if(_auditableEntitySaveChangesInterceptor is not null)
        //    optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ITIMSConfig).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}