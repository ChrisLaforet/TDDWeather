namespace TDDWeather
{
	public interface IHandlersProvider
	{
		ILocationQueryHandler GetLocationQueryHandler();
	}
}