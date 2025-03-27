using System.ComponentModel.DataAnnotations;

namespace ViafacilProdutos.Dtos;

public record struct QueryProductDto
(
    [Range(1, int.MaxValue)] int Limit
);
