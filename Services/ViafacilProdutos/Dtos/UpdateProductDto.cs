using System.ComponentModel.DataAnnotations;

namespace ViafacilProdutos.Dtos;

public record struct UpdateProductDto
(
    // [Required] int Id,
    [StringLength(maximumLength: 100, MinimumLength = 1)] string? Name,
    [StringLength(maximumLength: 200, MinimumLength = 0)] string? Description,
    [Range(0, int.MaxValue)] int? Amount,
    [Range(0.01, float.MaxValue)] float? Value
);
