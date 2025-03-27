using System.ComponentModel.DataAnnotations;

namespace ViafacilProdutos.Dtos;

public record struct CreateProductDto
(
    [Required][StringLength(maximumLength: 100, MinimumLength = 1)] string Name,
    [StringLength(maximumLength: 200, MinimumLength = 0)] string Description,
    [Required][Range(0, int.MaxValue)] int Amount,
    [Required][Range(0.01, float.MaxValue)] float Value
);
