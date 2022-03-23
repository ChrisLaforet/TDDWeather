using System.Text.Json;
using System.Text.Json.Nodes;

namespace TDDWeather
{
	public class OwmLocationResponse : ILocation
	{
		private JsonNode document;

		public OwmLocationResponse(string jsonResponse) => document = JsonNode.Parse(jsonResponse)!;

		public string GetCity()
		{
			// int hotHigh = forecastNode["TemperatureRanges"]!["Hot"]!["High"]!.GetValue<int>();
			//  JsonArray datesAvailable = forecastNode!["DatesAvailable"]!.AsArray()!;
			// Console.WriteLine($"DatesAvailable[0]={datesAvailable[0]}");
			throw new System.NotImplementedException();
		}

		public double GetLatitude()
		{
			throw new System.NotImplementedException();
		}

		public double GetLongitude()
		{
			throw new System.NotImplementedException();
		}
	}
}