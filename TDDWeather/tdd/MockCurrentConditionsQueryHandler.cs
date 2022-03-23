namespace TDDWeather
{
    public class MockCurrentConditionsQueryHandler : ICurrentConditionsQueryHandler
    {
        private const string BURLINGTON_WEATHER = "{\"coord\":{\"lon\":-79.4378,\"lat\":36.0957},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":287.38,\"feels_like\":287.13,\"temp_min\":286.75,\"temp_max\":288.5,\"pressure\":1015,\"humidity\":87},\"visibility\":10000,\"wind\":{\"speed\":2.06,\"deg\":120},\"clouds\":{\"all\":93},\"dt\":1648043284,\"sys\":{\"type\":1,\"id\":3521,\"country\":\"US\",\"sunrise\":1648034218,\"sunset\":1648078293},\"timezone\":-14400,\"id\":4458228,\"name\":\"Burlington\",\"cod\":200}";

        public ICurrentConditions GetCurrentConditionsFor(double latitude, double longitude)
        {
            return new OwmCurrentConditionsResponse(BURLINGTON_WEATHER);
        }
    }
}