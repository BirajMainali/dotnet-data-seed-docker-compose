using System.Reflection;
using dotnet_data_seed_docker_compose.Data;
using dotnet_data_seed_docker_compose.SeedContributors.Abstract;
using Microsoft.EntityFrameworkCore;

namespace dotnet_data_seed_docker_compose.Helper;

public class DatabaseSeedHelper
{
    private readonly AppDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public DatabaseSeedHelper(AppDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        await _context.Database.MigrateAsync();

        var contributorType = typeof(SeedContributor);
        var contributorTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => contributorType.IsAssignableFrom(x) && !x.IsAbstract);

        foreach (var type in contributorTypes)
        {
            var contributor = (SeedContributor)_serviceProvider.GetRequiredService(type);
            await contributor.SeedAsync();
        }
    }
}