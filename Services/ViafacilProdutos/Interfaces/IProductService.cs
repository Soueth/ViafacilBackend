using ViafacilProdutos.Dtos;
using ViafacilProdutos.Entities;

namespace ViafacilProdutos.Interfaces;

public interface IProductService
{
    Task<Product> CreateProduct(CreateProductDto product);
    Task<bool?> UpdateProduct(Guid id, UpdateProductDto product);
    Task<Product?> FindProduct(Guid id);
    Task<List<Product>> FindProducts(QueryProductDto queryDto);
    Task<bool> CheckProductsAvability(CheckProductDto[] checkingProducts);
    Task<bool?> DeleteProduct(Guid id);
    Task<bool> SubtractProducts(CheckProductDto[] updateProducts);
}
