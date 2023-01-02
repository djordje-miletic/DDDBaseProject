using DDD.Migrations.Extensions;
using FluentMigrator;

namespace DDD.Migrations.Migrations
{
    [Migration(20230102091701)]
    public class AddWeatherForecastsTable : Migration
    {
        public override void Up()
        {
            this.Create.Table("WeatherForecasts")
                .WithGuidIdColumn().WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("TemperatureC").AsInt32().NotNullable()
                .WithColumn("Summary").AsString(200).Nullable();
        }

        public override void Down()
        {
            this.Delete.Table("WeatherForecast");
        }
    }
}
