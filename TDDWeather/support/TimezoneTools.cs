using System;

namespace TDDWeather
{
	public class TimezoneTools
	{
		public static int ExtractDayFrom(DateTime utc, int offsetSeconds)
		{
			return ExtractDayFrom(GetDateTimeForZone(utc, offsetSeconds));
		}

		public static int ExtractDayFrom(DateTimeOffset dateTime)
		{
			return (int) dateTime.DayOfWeek;
		}

		public static DateTimeOffset GetDateTimeForZone(DateTime utc, int offsetSeconds)
		{
			var diff = new TimeSpan(0, 0, offsetSeconds);
			return new DateTimeOffset(utc.Ticks + diff.Ticks, diff);
		}
	}
}