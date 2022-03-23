using System;
using System.Collections.Generic;
using System.Text;

namespace TDDWeather
{
	public class OwmLocationQueryHandler : ILocationQueryHandler
	{
		public const string QUERY_STRING = "https://api.openweathermap.org/data/2.5/weather";

		private IApiOperation apiOperation;
		private string apiKey;

		public OwmLocationQueryHandler(IApiOperation apiOperation, string apiKey)
		{
			this.apiOperation = apiOperation;
			this.apiKey = apiKey;
		}

		public ILocation GetLocationFor(string city, string country, string state = null)
		{
			var sb = new StringBuilder();
			sb.Append(city);
			if (!string.IsNullOrEmpty(state))
			{
				sb.Append(",");
				sb.Append(state);
			}
			sb.Append(",");
			sb.Append(country);

			var parameters = new List<(string key, string value)>();
			parameters.Add(("q", sb.ToString()));

			var response = apiOperation.PerformGET(QUERY_STRING, parameters, apiKey);
			if (string.IsNullOrEmpty(response))
			{
				return null;
			}

			return new OwmLocationResponse(response);
		}
	}
}