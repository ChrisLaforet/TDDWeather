namespace TDDWeather
{
	public class MockLocationQueryHandler : ILocationQueryHandler
	{
		public ILocation GetLocationFor(string city, string country, string state)
		{
			throw new System.NotImplementedException();
		}
	}
}