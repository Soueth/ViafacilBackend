using System.ComponentModel.DataAnnotations;

namespace ViafacilReceipts.Dtos;

public record struct QueryReceiptDto
(
    [Range(1, int.MaxValue)] int Limit
);
