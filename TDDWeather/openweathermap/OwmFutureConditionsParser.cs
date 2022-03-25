using System;
using System.Collections.Generic;
using System.Linq;
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
			var lookup = new Dictionary<int, DayConditions>();

			var tzDiffSeconds = document["city"]!["timezone" ]!.GetValue<int>();

			foreach (var entry in document["list"]!.AsArray())
			{
				var unixTime = entry["dt"]!.GetValue<int>();
				var dateTime = TimezoneTools.GetDateTimeForZone(Converters.UnixTimestampToUtc(unixTime), tzDiffSeconds);
				var day = TimezoneTools.ExtractDayFrom(dateTime);
				if (!lookup.ContainsKey(day))
				{
					lookup[day] = new DayConditions(dateTime);
				}

				var conditions = new Conditions();
				conditions.MaximumTemperature = entry["main"]!["temp_max"]!.GetValue<double>();
				conditions.MinimumTemperature = entry["main"]!["temp_min"]!.GetValue<double>();
				conditions.ConditionCode = entry["weather"]!.AsArray()![0]!["main"]!.GetValue<string>();
				conditions.ConditionDescription = entry["weather"]!.AsArray()![0]!["description"]!.GetValue<string>();
				conditions.CloudCoveragePercent = entry["clouds"]!["all"]!.GetValue<int>();

				lookup[day].AddConditions(conditions);
			}
			
			var response = lookup.Values.AsEnumerable().ToList();
			response.Sort((a,b) => a.Date.CompareTo(b.Date));
			return response;
		}
	}

	internal class Conditions
	{
		public string ConditionCode { get; set; }
		public string ConditionDescription { get; set; }
		public int CloudCoveragePercent { get; set; }
		public double MinimumTemperature { get; set; }
		public double MaximumTemperature { get; set; }
	}

	internal class DayConditions
	{
		public DateTimeOffset Date { get; private set; }
		private List<Conditions> conditions = new List<Conditions>();

		public DayConditions(DateTimeOffset date) => this.Date = date;

		public void AddConditions(Conditions conditions)
		{
			this.conditions.Add(conditions);
		}
	}
}