using dotnet_data_seed_docker_compose.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_data_seed_docker_compose.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Weather> Weathers { get; set; }
}