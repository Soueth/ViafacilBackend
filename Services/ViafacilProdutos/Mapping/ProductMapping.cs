using ViafacilProdutos.Dtos;
using ViafacilProdutos.Entities;

namespace ViafacilProdutos.Mapping;

public static class ProductMapping
{
    public static Product ToProduct(this CreateProductDto createDto)
    {
        return new Product
        {
            Name = createDto.Name,
            Description = createDto.Description,
            Amount = createDto.Amount,
            Value = createDto.Value,
        };
    }

    // public static Product ToProduct(this UpdateProductDto updateDto)
    // {
    //     return new Product
    //     {
    //         Name = updateDto.Name,
    //         Description = updateDto.Description,
    //         Amount = updateDto.Amount
    //     };
    // }
}
