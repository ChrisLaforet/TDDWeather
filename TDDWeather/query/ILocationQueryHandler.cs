namespace TDDWeather
{
	public interface ILocationQueryHandler
	{
		ILocation GetLocationFor(string city, string country, string state);
	}
}