using Xunit;

namespace TDDWeather
{
    public class TDDWeatherTests
    {
        private const string CITY = "Burlington";
        private const string STATE = "NC";
        private const string COUNTRY = "US";
        private const double LATITUDE = 36.0957;
        private const double LONGITUDE = -79.4378;
     
        private IHandlersProvider provider = new TestHandlersProvider();
        
        [Fact]
        public void GivenTemperatureInCelsius_WhenConverted_ThenReturnsFahrenheit()
        {
            Assert.Equal(122, Converters.CelsiusToFahrenheit(50));
            Assert.Equal(68, Converters.CelsiusToFahrenheit(20));
            Assert.Equal(32, Converters.CelsiusToFahrenheit(0));
        }

        [Fact]
        public void GivenTemperatureInKelvin_WhenConverted_ThenReturnsCelsius()
        {
            Assert.Equal(-23.1, Converters.KelvinToCelsius(250));
            Assert.Equal(50, Converters.KelvinToCelsius(323.15));
            Assert.Equal(86, Converters.KelvinToCelsius(359.15));
        }

        [Fact]
        public void GivenWindSpeedInMetersPerSec_WhenConverted_ThenReturnsKnots()
        {
            Assert.Equal(58.3, Converters.MetersPerSecondToKnots(30));
            Assert.Equal(0, Converters.MetersPerSecondToKnots(0));
            Assert.Equal(15, Converters.MetersPerSecondToKnots(7.71667));
        }

        [Fact]
        public void GivenUnixTimestamp_WhenConverted_ThenReturnUTC()
        {
            Assert.Equal("1/1/1970 12:00:00 AM", Converters.UnixTimestampToUTC(0).ToString());
            Assert.Equal("3/24/2022 3:45:36 AM", Converters.UnixTimestampToUTC(1648093536).ToString());
        }
        
        [Fact]
        public void GivenNonExistentLocation_WhenLocationQueryHandled_ThenReturnsNull()
        {
            Assert.Null(provider.GetLocationQueryHandler().GetLocationFor(null, null, null));
        }

        [Fact]
        public void GivenValidLocation_WhenLocationQueryHandled_ThenReturnsValidResponse()
        {
            var location = provider.GetLocationQueryHandler().GetLocationFor(CITY, COUNTRY, STATE);
            Assert.NotNull(location);
            Assert.Equal(CITY, location.GetCity());
            Assert.Equal(LATITUDE, location.GetLatitude());
            Assert.Equal(LONGITUDE, location.GetLongitude());
        }

        [Fact]
        public void GivenValidLocation_WhenCurrentConditionsQueryHandled_ThenReturnsValidResponse()
        {
            var conditions = provider.GetCurrentConditionsQueryHandler().GetCurrentConditionsFor(LATITUDE, LONGITUDE);
            Assert.NotNull(conditions);
            Assert.Equal(14.2, conditions.GetTemperatureInCelsius());
            Assert.Equal(4.0, conditions.GetWindSpeedInKnots());
            Assert.Equal(93, conditions.GetCloudCoveragePercent());
            Assert.Equal("Clouds", conditions.GetConditionCode());
            Assert.Equal("overcast clouds", conditions.GetConditionDescription());
            Assert.Equal("3/23/2022 11:16:58 AM", conditions.GetSunriseTime().ToString());
        }

        [Fact]
        public void GivenValidLocation_WhenFutureConditionsQueryHandler_ThenReturnsValidResponse()
        {
            var conditions = provider.GetFutureConditionsQueryHandler().GetFutureConditionsFor(LATITUDE, LONGITUDE);
            Assert.NotNull(conditions);
            Assert.NotEmpty(conditions);
        }
    }
}