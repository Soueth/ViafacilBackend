using System.ComponentModel.DataAnnotations;

namespace ViafacilReceipts.Dtos;

public record struct UpdateReceiptDto
(
    [StringLength(200, MinimumLength = 1)] string? Annotations,
    [Required][StringLength(50, MinimumLength = 3)] string CustomerName,
    [Required][StringLength(13, MinimumLength = 11)] string CustomerDocument
);
