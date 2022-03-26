using System;

namespace TDDWeather
{
	public interface IFutureConditions
	{
		DateTimeOffset GetForecastDate();
		string GetDayOfWeek();
		string GetConditionCode();
		int GetMinimumCloudCoveragePercent();
		int GetMaximumCloudCoveragePercent();
		double GetMinimumTemperatureInCelsius();
		double GetMaximumTemperatureInCelsius();
	}
}