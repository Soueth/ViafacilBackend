namespace OGSimpReleases.Dtos;

public record class UpdateReleaseDto
(
    double Value,
    string? Description,
    DateTime Date
);