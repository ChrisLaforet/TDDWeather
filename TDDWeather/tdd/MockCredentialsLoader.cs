namespace TDDWeather
{
	public class MockCredentialsLoader : ICredentialsLoader
	{
		public string GetApiKey() => "APIKEY";
	}
}