using DDD.Domain.Common;
using DDD.Domain.Exceptions;

namespace DDD.Domain.Entities.ValueObjects
{
    public class Temperature : ValueObject
    {
        private int Value { get; set; }

        public int TemperatureC => Value;

        public int TemperatureF => 32 + (int)(Value / 0.5556);

        private Temperature()
        {

        }

        public Temperature(int temperature)
        {
            if (temperature < -273)
            {
                throw new InvalidTemperatureException("Temperature can't be below -273°C");
            }

            this.Value = temperature;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
