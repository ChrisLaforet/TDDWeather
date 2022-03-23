using System;

namespace TDDWeather
{
    public class Converters
    {
        public static double CelsiusToFahrenheit(double celsius)
        {
            return Math.Round(9.0 / 5.0 * celsius + 32.0, 1, MidpointRounding.ToZero);
        }

        public static double KelvinToCelsius(double kelvin)
        {
            return Math.Round(kelvin - 273.15, 1, MidpointRounding.ToZero);
        }

        public static double MetersPerSecondToKnots(double ms)
        {
            return Math.Round(ms * 1.944, 1, MidpointRounding.ToZero);
        }
    }
}