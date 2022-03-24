using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace TDDWeather
{
	public class OwmFutureConditionsParser
	{
		public static List<IFutureConditions> Parse(string jsonResponse)
		{
			var response = new List<IFutureConditions>();

			// divide up entries into days taking tz into account
			var dayConditions = ExtractDayConditionsFrom(jsonResponse);

			// order days

			// process each day to derive the values


			return response;
		}

		private static List<DayConditions> ExtractDayConditionsFrom(string jsonResponse)
		{
			var document = JsonNode.Parse(jsonResponse)!;
			var lookup = new Dictionary<int, List<DayConditions>>();

			var tzDiffSeconds = document["city"]!["timezone" ]!.GetValue<int>();

			foreach (var entry in document["list"]!.AsArray())
			{

			}

			return null;
		}
	}

	internal class Conditions
	{
		public string GetConditionCode { get; set; }
		public string GetConditionDescription { get; set; }
		public int GetCloudCoveragePercent { get; set; }
		public double GetMinimumTemperature { get; set; }
		public double GetMaximumTemperature { get; set; }
	}

	internal class DayConditions
	{
		public DateTime Date { get; private set; }
		private List<Conditions> conditions = new List<Conditions>();

		public DayConditions(DateTime date) => this.Date = date;

		public void AddConditions(Conditions conditions)
		{
			this.conditions.Add(conditions);
		}
	}
}