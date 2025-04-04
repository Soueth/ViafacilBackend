using System.ComponentModel.DataAnnotations;

namespace OGSimpSharedTypes;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

