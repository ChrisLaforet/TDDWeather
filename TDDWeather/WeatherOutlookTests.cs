using Xunit;

namespace TDDWeather
{
    public class TDDWeatherTests
    {
        [Fact]
        public void GivenTemperatureInCelsius_WhenConverted_ThenReturnsFahrenheit()
        {
            Assert.Equal(122, Converters.CelsiusToFahrenheit(50));
            Assert.Equal(68, Converters.CelsiusToFahrenheit(20));
            Assert.Equal(32, Converters.CelsiusToFahrenheit(0));
        }

    }
}