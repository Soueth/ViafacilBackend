using Microsoft.AspNetCore.Mvc;
using ViafacilProdutos.Dtos;
using ViafacilProdutos.Entities;
using ViafacilProdutos.Interfaces;

namespace ViafacilProdutos.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet()]
    public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] QueryProductDto query)
    {
        return await _productService.FindProducts(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(Guid id)
    {
        Product? product = await _productService.FindProduct(id);
        if (product == null) return NotFound();

        return product;
    }

    [HttpPost("checkProducts")]
    public async Task<ActionResult> CheckProducts([FromBody] CheckProductDto[] ids)
    {
        bool result = await _productService.CheckProductsAvability(ids);

        return result ? Ok() : Forbid();
    }
    
    [HttpPost()]
    public async Task<IResult> CreateProduct([FromBody] CreateProductDto createProduct)
    {
        Product product = await _productService.CreateProduct(createProduct);

        return Results.CreatedAtRoute
        (
            nameof(CreateProduct),
            new { id = product.Id },
            product
        );
    }

    [HttpPatch()]
    public async Task<ActionResult<bool?>> UpdateProduct(Guid id, [FromBody] UpdateProductDto updateProduct)
    {
        bool? success = await _productService.UpdateProduct(id, updateProduct);

        if (success == null) return NotFound();
        
        return success;
    }

    [HttpPatch("subtractProducts")]
    public async Task<ActionResult<bool?>> SubtractProducts([FromBody] CheckProductDto[] updateProducts)
    {
        bool result = await _productService.SubtractProducts(updateProducts);

        return result? Ok() : Forbid();
    }
}
