namespace TDDWeather
{
	public class MockLocationQueryHandler : ILocationQueryHandler
	{
		private const string BURLINGTON_GEO_RESPONSE = "{\"coord\":{\"lon\":-79.4378,\"lat\":36.0957},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"base\":\"stations\",\"main\":{\"temp\":287.87,\"feels_like\":287.77,\"temp_min\":287,\"temp_max\":289.79,\"pressure\":1015,\"humidity\":91},\"visibility\":10000,\"wind\":{\"speed\":2.06,\"deg\":0},\"rain\":{\"1h\":0.52},\"clouds\":{\"all\":100},\"dt\":1648046198,\"sys\":{\"type\":1,\"id\":3521,\"country\":\"US\",\"sunrise\":1648034218,\"sunset\":1648078293},\"timezone\":-14400,\"id\":4458228,\"name\":\"Burlington\",\"cod\":200}";

		public ILocation GetLocationFor(string city, string country, string state = null)
		{
			if (city == null && country == null)
			{
				return null;
			}
			return new OwmLocationResponse(BURLINGTON_GEO_RESPONSE);
		}
	}
}