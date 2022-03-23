using System;

namespace TDDWeather
{
    public class WeatherOutlook
    {
        private IHandlersProvider handlersProvider;

        public WeatherOutlook(IHandlersProvider handlersProvider) => this.handlersProvider = handlersProvider;

        public ILocation GetLocationFor(string city, string country, string state = null)
        {
            return handlersProvider.GetLocationQueryHandler().GetLocationFor(city, country, state);
        }
    }
}