namespace TDDWeather
{
	public interface IApiOperation
	{
		string PerformGET(string url, string parameters, string apiKey);
	}
}