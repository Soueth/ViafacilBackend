using System.ComponentModel.DataAnnotations;

namespace ViafacilReceipts.Dtos;

public record struct ProductDto
(
    [Required] Guid Id,
    [Required][Range(0, int.MaxValue)] int Amount,
    [Required][Range(0, float.MaxValue)] float Value
);
