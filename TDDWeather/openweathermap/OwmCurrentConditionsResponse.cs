using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace TDDWeather
{
    public class OwmCurrentConditionsResponse : ICurrentConditions
    {
        private JsonNode document;

        public OwmCurrentConditionsResponse(string jsonResponse) => document = JsonNode.Parse(jsonResponse)!;
        
        public string GetConditionCode()
        {
            return document["weather"]!.AsArray()![0]!["main"]!.GetValue<string>();
        }

        public string GetConditionDescription()
        {
            return document["weather"]!.AsArray()![0]!["description"]!.GetValue<string>();
        }

        public int GetCloudCoveragePercent()
        {
            return document["clouds"]!["all"]!.GetValue<int>();
        }

        public double GetTemperatureInCelsius()
        {
            return Converters.KelvinToCelsius(document["main"]!["temp"]!.GetValue<double>());
        }

        public double GetMinimumTemperatureInCelsius()
        {
            return Converters.KelvinToCelsius(document["main"]!["temp_min"]!.GetValue<double>());
        }

        public double GetMaximumTemperatureInCelsius()
        {
            return Converters.KelvinToCelsius(document["main"]!["temp_max"]!.GetValue<double>());
        }

        public int GetHumidityInPercent()
        {
            return document["main"]!["humidity"]!.GetValue<int>();
        }

        public int GetVisibilityInFeet()
        {
            return document["visibility"]!.GetValue<int>();
        }

        public double GetWindSpeedInKnots()
        {
            return Converters.MetersPerSecondToKnots(document["wind"]!["speed"]!.GetValue<double>());
        }

        public int GetWindDirectionInDegrees()
        {
            return document["wind"]!["deg"]!.GetValue<int>();
        }

        public DateTime GetSunriseTime()
        {
            return Converters.UnixTimestampToUtc(document["sys"]!["sunrise"].GetValue<int>());
        }

        public DateTime GetSunsetTime()
        {
            return Converters.UnixTimestampToUtc(document["sys"]!["sunset"].GetValue<int>());
        }
    }
}