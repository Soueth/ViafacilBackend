namespace OGSimpReleases.Entities;

public abstract class Release : Entity
{   
    public double Value { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    // public ReleaseType ReleaseType { get; set; }
}
