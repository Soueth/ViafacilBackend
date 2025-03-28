using System;

namespace OGSimpReleases.Entities;

public class ManagedItem : Entity
{
    public virtual Revenue Revenue { get; set; } = null!;
}
