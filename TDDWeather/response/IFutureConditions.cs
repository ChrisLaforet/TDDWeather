using System;

namespace TDDWeather
{
	public interface IFutureConditions
	{
		DateTime GetForecastDate();
		string GetConditionCode();
		int GetMinimumCloudCoveragePercent();
		int GetMaximumCloudCoveragePercent();
		double GetMinimumTemperatureInCelsius();
		double GetMaximumTemperatureInCelsius();
	}
}