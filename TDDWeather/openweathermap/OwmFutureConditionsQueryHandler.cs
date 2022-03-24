using System.Collections.Generic;

namespace TDDWeather
{
	public class OwmFutureConditionsQueryHandler : IFutureConditionsQueryHandler
	{
		public const string QUERY_STRING = "https://api.openweathermap.org/data/2.5/forecast";

		private IApiOperation apiOperation;
		private string apiKey;

		public OwmFutureConditionsQueryHandler(IApiOperation apiOperation, string apiKey)
		{
			this.apiOperation = apiOperation;
			this.apiKey = apiKey;
		}

		public List<IFutureConditions> GetFutureConditionsFor(double latitude, double longitude)
		{
			var parameters = new List<(string key, string value)>();
			parameters.Add(("lat", latitude.ToString()));
			parameters.Add(("lon", longitude.ToString()));

			var response = apiOperation.PerformGET(QUERY_STRING, parameters, apiKey);
			if (string.IsNullOrEmpty(response))
			{
				return null;
			}

			return OwmFutureConditionsParser.Parse(response);
		}
	}
}