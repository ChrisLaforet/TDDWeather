using System;

namespace TDDWeather
{
    public class OwmFutureConditionResponse : IFutureConditions
    {
        private DateTimeOffset forecastDate;
        private string conditionCode;
        private int minimumCloudCoveragePercent;
        private int maximumCloudCoveragePercent;
        private double minimumTemperatureInKelvin,
        private double maximumTemperatureInKelvin;

        public OwmFutureConditionResponse(DateTimeOffset date, string conditionCode,
            int minimumCloudCoveragePercent, int maximumCloudCoveragePercent,
            double minimumTemperatureInKelvin, double maximumTemperatureInKelvin)
        {
            forecastDate = date;
            this.conditionCode = conditionCode;
            this.minimumCloudCoveragePercent = minimumCloudCoveragePercent;
            this.maximumCloudCoveragePercent = maximumCloudCoveragePercent;
            this.minimumTemperatureInKelvin = minimumTemperatureInKelvin;
            this.maximumTemperatureInKelvin = maximumCloudCoveragePercent;
        }


        public DateTimeOffset GetForecastDate()
        {
            return forecastDate;
        }

        public string GetDayOfWeek()
        {
            return forecastDate.DayOfWeek.ToString();
        }

        public string GetConditionCode()
        {
            return conditionCode;
        }

        public int GetMinimumCloudCoveragePercent()
        {
            return minimumCloudCoveragePercent;
        }

        public int GetMaximumCloudCoveragePercent()
        {
            return maximumCloudCoveragePercent;
        }

        public double GetMinimumTemperatureInCelsius()
        {
            return Converters.KelvinToCelsius(minimumTemperatureInKelvin);
        }

        public double GetMaximumTemperatureInCelsius()
        {
            return Converters.KelvinToCelsius(maximumTemperatureInKelvin);
        }
    }
}