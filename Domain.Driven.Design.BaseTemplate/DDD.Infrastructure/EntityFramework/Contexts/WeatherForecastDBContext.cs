using DDD.Domain.Entities.AggregateRoots;
using DDD.Infrastructure.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.EntityFramework.Contexts
{
    public class WeatherForecastDBContext : DbContext
    {
        public WeatherForecastDBContext(DbContextOptions<WeatherForecastDBContext> options) 
            : base(options) 
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherForecastConfigurations());
        }
    }
}
