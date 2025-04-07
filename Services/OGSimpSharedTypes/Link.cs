using System;
using System.ComponentModel.DataAnnotations;

namespace OGSimpSharedTypes;

public class Link
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
