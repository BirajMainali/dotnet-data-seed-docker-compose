namespace dotnet_data_seed_docker_compose.SeedContributors.Abstract;

public abstract class SeedContributor
{
    public abstract Task SeedAsync(CancellationToken cancellationToken = default);
}