namespace dotnet_data_seed_docker_compose.Models;

public class Weather
{
    public DateTime Date { get; set; }
    
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public int TemperatureC { get; set; }
    public int TemperatureF { get; set; }
}