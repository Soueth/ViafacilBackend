using System.ComponentModel.DataAnnotations;
using ViafacilReceipts.Typing;

namespace ViafacilReceipts.Entities;

public class Receipt
{
    [Key]
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public Status Status { get; set; }
    public float Value { get; set; }
    public string Annotations { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerDocument { get; set; } = string.Empty;
    public Guid[] Products { get; set; } = Array.Empty<Guid>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
}
