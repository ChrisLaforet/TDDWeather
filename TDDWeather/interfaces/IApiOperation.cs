using System.Collections.Generic;

namespace TDDWeather
{
	public interface IApiOperation
	{
		string PerformGET(string url, List<(string key, string value)> parameters, string apiKey);
	}
}