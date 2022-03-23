namespace TDDWeather
{
	public interface IFutureConditions
	{
		string GetConditionCode();
		string GetConditionDescription();
		int GetCloudCoveragePercent();
		double GetTemperatureInCelsius();
		double GetMinimumTemperatureInCelsius();
		double GetMaximumTemperatureInCelsius();
		int GetSunriseTime();
		int GetSunsetTime();
	}
}