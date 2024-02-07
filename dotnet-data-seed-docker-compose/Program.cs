using dotnet_data_seed_docker_compose.Data;
using dotnet_data_seed_docker_compose.Helper;
using dotnet_data_seed_docker_compose.SeedContributors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<WeatherSeedContributor>();
builder.Services.AddScoped<DatabaseSeedHelper>();
builder.Services.AddTransient<IServiceProvider, ServiceProvider>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var helper = scope.ServiceProvider.GetRequiredService<DatabaseSeedHelper>();
    await helper.MigrateAsync();
}

app.MapGet("/", () => "Hello World!");

app.Run();