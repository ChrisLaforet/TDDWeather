using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TDDWeather
{
    public class HttpApiOperation : IApiOperation
    {
        public string PerformGET(string url, List<(string key, string value)> parameters, string apiKey)
        {
            HttpClient client;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
 //               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var preparedParameters = PrepareParameters(parameters, apiKey);

                var response = client.GetAsync(preparedParameters).Result;  // TODO - FIX - Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        private static string PrepareParameters(List<(string key, string value)> parameters, string apiKey)
        {
            var sb = new StringBuilder();
            foreach (var parameter in parameters)
            {
                if (sb.Length > 0)
                {
                    sb.Append("&");
                }

                sb.Append(parameter.key);
                sb.Append("=");
                sb.Append(parameter.value);
            }

            if (!string.IsNullOrEmpty(apiKey))
            {
                if (sb.Length > 0)
                {
                    sb.Append("&");
                }

                sb.Append("appid");
                sb.Append("=");
                sb.Append(apiKey);
            }

            return sb.Length > 0 ? sb.ToString() : null;
        }
    }
}