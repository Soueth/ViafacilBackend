namespace OGSimpSharedTypes;

public class Item : Entity
{
    public string Name { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Description { get; set; } = string.Empty;
    public virtual ICollection<Link> Links { get; set; } = new List<Link>();
}
