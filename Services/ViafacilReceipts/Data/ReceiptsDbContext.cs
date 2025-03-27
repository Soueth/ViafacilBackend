using Microsoft.EntityFrameworkCore;
using ViafacilReceipts.Entities;

namespace ViafacilReceipts.Data;

public class ReceiptsContext : DbContext
{
    public DbSet<Receipt> Receipts => Set<Receipt>();

    public ReceiptsContext(DbContextOptions<ReceiptsContext> options)
        :base(options) {}
}
