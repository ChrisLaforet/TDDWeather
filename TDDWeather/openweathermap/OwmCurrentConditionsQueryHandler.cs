using System.Collections.Generic;

namespace TDDWeather
{
    public class OwmCurrentConditionsQueryHandler : ICurrentConditionsQueryHandler
    {
        public const string QUERY_STRING = "https://api.openweathermap.org/data/2.5/weather";

        private IApiOperation apiOperation;
        private string apiKey;

        public OwmCurrentConditionsQueryHandler(IApiOperation apiOperation, string apiKey)
        {
            this.apiOperation = apiOperation;
            this.apiKey = apiKey;
        }

        public ICurrentConditions GetCurrentConditionsFor(double latitude, double longitude)
        {
            var parameters = new List<(string key, string value)>();
            parameters.Add(("lat", latitude.ToString()));
            parameters.Add(("lon", longitude.ToString()));

            var response = apiOperation.PerformGET(QUERY_STRING, parameters, apiKey);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }

            return new OwmCurrentConditionsResponse(response);
        }
    }
}