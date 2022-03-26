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

			// process each day to derive the values
			dayConditions.ForEach(dc => response.Add(ProcessDayConditionsFor(dc)));


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

		private static IFutureConditions ProcessDayConditionsFor(DayConditions dayConditions)
		{
			var maxTemp = 0.0d;
			var minTemp = 0.0d;
			var maxCloudPercent = 0;
			var minCloudPercent = 100;
			var conditionCodes = new Dictionary<string, int>();
			dayConditions.GetConditions().ForEach(condition =>
			{
				maxTemp = maxTemp < condition.MaximumTemperature ? condition.MaximumTemperature : maxTemp;
				minTemp = minTemp == 0 || minTemp > condition.MinimumTemperature ? condition.MinimumTemperature : minTemp;
				maxCloudPercent = maxCloudPercent < condition.CloudCoveragePercent ? condition.CloudCoveragePercent : maxCloudPercent;
				minCloudPercent = minCloudPercent > condition.CloudCoveragePercent ? condition.CloudCoveragePercent : minCloudPercent;
				if (conditionCodes.ContainsKey(condition.ConditionCode))
				{
					conditionCodes[condition.ConditionCode] = conditionCodes[condition.ConditionCode] + 1;
				}
				else
				{
					conditionCodes[condition.ConditionCode] = 1;
				}
			});
			
			return new OwmFutureConditionResponse(dayConditions.Date, ExtractConditionCodeFrom(conditionCodes), minCloudPercent,
				maxCloudPercent, minTemp, maxTemp);
		}

		private static string ExtractConditionCodeFrom(Dictionary<string, int> conditionCodes)
		{
			var currentCount = 0;
			var currentCode = string.Empty;
			foreach (var conditionCode in conditionCodes)
			{
				if (conditionCode.Value > currentCount)
				{
					currentCount = conditionCode.Value;
					currentCode = conditionCode.Key;
				}				
			}

			return currentCode;
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

		public List<Conditions> GetConditions()
		{
			return conditions;
		}
	}
}