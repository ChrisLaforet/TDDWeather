using System;

namespace TDDWeather
{
	public interface ICurrentConditions
	{
		string GetConditionCode();
		string GetConditionDescription();
		int GetCloudCoveragePercent();
		double GetTemperatureInCelsius();
		double GetMinimumTemperatureInCelsius();
		double GetMaximumTemperatureInCelsius();
		int GetHumidityInPercent();
		int GetVisibilityInFeet();
		double GetWindSpeedInKnots();
		int GetWindDirectionInDegrees();
		DateTime GetSunriseTime();
		DateTime GetSunsetTime();
	}
}