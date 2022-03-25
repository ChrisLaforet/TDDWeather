using System;

namespace TDDWeather
{
	public interface IFutureConditions
	{
		DateTimeOffset GetForecastDate();
		string GetConditionCode();
		int GetMinimumCloudCoveragePercent();
		int GetMaximumCloudCoveragePercent();
		double GetMinimumTemperatureInCelsius();
		double GetMaximumTemperatureInCelsius();
	}
}