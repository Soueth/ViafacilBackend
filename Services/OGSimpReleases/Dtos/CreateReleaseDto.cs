using System.ComponentModel.DataAnnotations;

namespace OGSimpReleases.Dtos;

public record class CreateReleaseDto 
(
    [Required] double Value,
    [StringLength(maximumLength: 300, MinimumLength = 1)]string? Description,
    DateTime Date
);
