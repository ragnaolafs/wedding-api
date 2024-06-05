using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class WeddingContext : DbContext
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in ChangeTracker.Entries<IDateProperties>())
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.CreatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    
    public WeddingContext() { }
    
    public WeddingContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<GuestEntity> Guest { get; set; }
}