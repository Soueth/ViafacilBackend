using System;
using System.ComponentModel.DataAnnotations;

namespace OGSimpReleases.Entities;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
