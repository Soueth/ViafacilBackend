using Microsoft.EntityFrameworkCore;
using ViafacilProdutos.Data;
using ViafacilProdutos.Dtos;
using ViafacilProdutos.Entities;
using ViafacilProdutos.Interfaces;
using ViafacilProdutos.Mapping;

namespace ViafacilProdutos.Services;

public class ProductService : IProductService
{
    private readonly ProductsContext _context;

    public ProductService(ProductsContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateProduct(CreateProductDto createProduct)
    {
        Product product = createProduct.ToProduct();

        var _product = _context.Add(product);

        await _context.SaveChangesAsync();

        return _product.Entity;
    }

    public async Task<Product?> FindProduct(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Product>> FindProducts(QueryProductDto queryDto)
    {
        return await _context.Products
            .Where(x => x.DeletedAt == null)
            .OrderByDescending(x => x.CreatedAt)
            .Take(queryDto.Limit)
            .ToListAsync();
    }

    public async Task<bool?> UpdateProduct(Guid id, UpdateProductDto updateProduct)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) return null;

        product.Name = updateProduct.Name ?? product.Name;
        product.Description = updateProduct.Description ?? product.Description;
        product.Amount = updateProduct.Amount ?? product.Amount;
        product.Value = updateProduct.Value ?? product.Value;
        product.UpdatedAt = DateTime.UtcNow;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool?> DeleteProduct(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) return null;

        product.DeletedAt = DateTime.UtcNow;

        // _context.Products.Remove(product);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> CheckProductsAvability(CheckProductDto[] products)
    {
        List<Product> result = await _context.Products.Where(p => products.Any(x => x.Id == p.Id && x.Amount < p.Amount)).ToListAsync();

        return result.Count() == products.Length;
    }

    public async Task<bool> SubtractProducts(CheckProductDto[] updateProducts)
    {
        await _context.Products.ForEachAsync(p => {
            CheckProductDto? product = updateProducts.FirstOrDefault(x => x.Id == p.Id);

            if (product != null && p.Amount >= product.Value.Amount)
            {
                p.Amount = p.Amount - product.Value.Amount;
            }
        });

        return await _context.SaveChangesAsync() > 0;
    }
}