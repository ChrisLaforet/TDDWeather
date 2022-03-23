namespace TDDWeather
{
	public class TestHandlersProvider : IHandlersProvider
	{
		public ILocationQueryHandler GetLocationQueryHandler()
		{
			return new MockLocationQueryHandler();
		}
	}
}