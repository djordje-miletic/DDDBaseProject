namespace DDD.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IWeatherForecastRepository WeatherForecastRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
