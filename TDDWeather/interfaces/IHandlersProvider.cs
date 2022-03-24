namespace TDDWeather
{
	public interface IHandlersProvider
	{
		ILocationQueryHandler GetLocationQueryHandler();
		ICurrentConditionsQueryHandler GetCurrentConditionsQueryHandler();
		IFutureConditionsQueryHandler GetFutureConditionsQueryHandler();
	}
}