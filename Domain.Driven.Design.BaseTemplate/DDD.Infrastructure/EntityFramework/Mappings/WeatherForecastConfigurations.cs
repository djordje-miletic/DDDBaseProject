using DDD.Domain.Entities.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.EntityFramework.Mappings
{
    public class WeatherForecastConfigurations : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.ToTable("WeatherForecasts");

            builder.HasKey(wf => wf.Id);

            builder.Property(wf => wf.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValue("NEWID()")
                .IsRequired();

            builder.OwnsOne(wf => wf.Temperature, wf =>
            {
                wf.Property("Value").HasColumnName("TemperatureC").IsRequired();
            });

            builder.Property(wf => wf.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(wf => wf.Summary)
                .HasColumnName("Summary")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(wf => wf.CreatedAt)
                .HasColumnType("datetime2");

            builder.Property(wf => wf.ModifiedAt)
                .HasColumnType("datetime2");

            builder.Property(wf => wf.CreatedBy)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(wf => wf.ModifiedBy)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);
        }
    }
}
