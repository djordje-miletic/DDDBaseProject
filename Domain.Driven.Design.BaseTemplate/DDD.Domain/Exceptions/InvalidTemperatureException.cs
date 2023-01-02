namespace DDD.Domain.Exceptions
{
    public class InvalidTemperatureException : DomainException
    {
        public InvalidTemperatureException(string? message) : base(message) { }
    }
}
