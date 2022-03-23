using System.Text.Json;
using System.Text.Json.Nodes;

namespace TDDWeather
{
	public class OwmLocationResponse : ILocation
	{
		private JsonNode document;

		public OwmLocationResponse(string jsonResponse) => document = JsonNode.Parse(jsonResponse)!;

		// See https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter?pivots=dotnet-7-0#deserialize-subsections-of-a-json-payload
		// int hotHigh = forecastNode["TemperatureRanges"]!["Hot"]!["High"]!.GetValue<int>();
		// JsonArray datesAvailable = forecastNode!["DatesAvailable"]!.AsArray()!;
		// Console.WriteLine($"DatesAvailable[0]={datesAvailable[0]}");

		public string GetCity()
		{
			return document["name"]!.GetValue<string>();
		}

		public double GetLatitude()
		{
			return document["lat"]!.GetValue<double>();
		}

		public double GetLongitude()
		{
			return document["long"]!.GetValue<double>();
		}
	}
}