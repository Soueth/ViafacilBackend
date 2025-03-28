using OGSimpReleases.Entities;

namespace OGSimpReleases.Interfaces;

public interface IReleaserService
{
    Task<TRelease> CreateReleaseAsync<TRelease>(TRelease release) where TRelease : Release;
}
