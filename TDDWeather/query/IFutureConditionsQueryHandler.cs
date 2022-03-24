using System.Collections.Generic;

namespace TDDWeather
{
	public interface IFutureConditionsQueryHandler
	{
		List<IFutureConditions> GetFutureConditionsFor(double latitude, double longitude);
	}
}