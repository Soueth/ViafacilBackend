using System.ComponentModel.DataAnnotations;

namespace ViafacilProdutos.Dtos;

public record struct CheckProductDto
(
    [Required] Guid Id,
    [Required] int Amount
);
