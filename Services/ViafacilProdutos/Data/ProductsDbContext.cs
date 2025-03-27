using Microsoft.EntityFrameworkCore;
using ViafacilProdutos.Entities;

namespace ViafacilProdutos.Data;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public ProductsContext(DbContextOptions<ProductsContext> options)
        :base(options) {}
}
