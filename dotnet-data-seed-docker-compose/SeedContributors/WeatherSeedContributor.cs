using dotnet_data_seed_docker_compose.Data;
using dotnet_data_seed_docker_compose.Models;
using dotnet_data_seed_docker_compose.SeedContributors.Abstract;
using Microsoft.EntityFrameworkCore;

namespace dotnet_data_seed_docker_compose.SeedContributors;

public class WeatherSeedContributor : SeedContributor
{
    private readonly AppDbContext _context;

    public WeatherSeedContributor(AppDbContext context)
    {
        _context = context;
    }

    public override async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await _context.Weathers.AnyAsync(cancellationToken))
        {
            return;
        }

        var weathers = new List<Weather>()
        {
            new Weather
            {
                Date = DateTime.UtcNow,
                Country = "USA",
                City = "New York",
                TemperatureC = 20,
                TemperatureF = 68
            },
            new Weather
            {
                Date = DateTime.UtcNow,
                Country = "Canada",
                City = "Toronto",
                TemperatureC = 15,
                TemperatureF = 59
            },
            new Weather
            {
                Date = DateTime.UtcNow,
                Country = "Australia",
                City = "Sydney",
                TemperatureC = 25,
                TemperatureF = 77
            }
        };

        await _context.AddRangeAsync(weathers, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}