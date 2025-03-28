using System;
using System.Collections;

namespace OGSimpReleases.Entities;

// Separando Lançamentos de Receitas e Despesas para favorecer escalabilidade, uma vez que podem ter mais diferenças entre essas entidades.
public class Revenue : Release
{
    public virtual ICollection<ManagedItem> ManagedItems { get; set; } = Array.Empty<ManagedItem>();
}
