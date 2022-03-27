namespace TDDWeather
{
	public class OwmHandlersProvider : IHandlersProvider
	{
		private IApiOperation apiOperation;
		private string apiKey;

		public OwmHandlersProvider(IApiOperation apiOperation, ICredentialsLoader credentialsLoader)
		{
			this.apiOperation = apiOperation;
			this.apiKey = credentialsLoader.GetApiKey();
		}

		public ILocationQueryHandler GetLocationQueryHandler()
		{
			return new OwmLocationQueryHandler(apiOperation, apiKey);
		}

		public ICurrentConditionsQueryHandler GetCurrentConditionsQueryHandler()
		{
			return new OwmCurrentConditionsQueryHandler(apiOperation, apiKey);
		}

		public IFutureConditionsQueryHandler GetFutureConditionsQueryHandler()
		{
			return new OwmFutureConditionsQueryHandler(apiOperation, apiKey);
		}
	}
}