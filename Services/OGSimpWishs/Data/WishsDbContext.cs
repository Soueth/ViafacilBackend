using Microsoft.EntityFrameworkCore;

namespace OGSimpWishs.Data;

public class WishsDbContext : DbContext
{
    public DbSet<Wish> Wishs => Set<Wish>();
    public DbSet<WishItem> WishItems => Set<WishItem>();

    public WishsDbContext(DbContextOptions<WishsDbContext> options)
        : base(options) { }
}
