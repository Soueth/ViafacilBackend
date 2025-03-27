using System.ComponentModel.DataAnnotations;
using ViafacilReceipts.Typing;

namespace ViafacilReceipts.Dtos;

public record struct CreateReceiptDto
(
    [Required][EnumDataType(typeof(Status))] Status Status, 
    [Required][MinLength(1)] List<ProductDto> Products,
    [StringLength(200, MinimumLength = 1)] string? Annotation,
    [Required][StringLength(50, MinimumLength = 3)] string CustomerName,
    [Required][StringLength(13, MinimumLength = 11)] string CustomerDocument
);
