using System.Collections.Generic;

namespace TDDWeather
{
	public class MockApiOperation : IApiOperation
	{
		private string expectedReturn;

		public MockApiOperation(string expectedReturn) => this.expectedReturn = expectedReturn;

		public string PerformGET(string url, List<(string key, string value)> parameters, string apiKey) => expectedReturn;
	}
}