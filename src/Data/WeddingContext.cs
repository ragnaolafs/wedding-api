using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class WeddingContext : DbContext
{
    public WeddingContext() { }
    
    public WeddingContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<GuestEntity> Guest { get; set; }
}