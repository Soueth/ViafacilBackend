using Microsoft.EntityFrameworkCore;
using OGSimpReleases.Entities;

namespace OGSimpReleases.Data;

public class ReleasesDbContext : DbContext
{
    public DbSet<Revenue> Revenues => Set<Revenue>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<ManagedItem> ManagedItems => Set<ManagedItem>();

    public ReleasesDbContext(DbContextOptions<ReleasesDbContext> options)
        : base(options) {}
}
