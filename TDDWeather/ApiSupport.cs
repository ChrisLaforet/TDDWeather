using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TDDWeather
{
    public class ApiSupport
    {
        private string PerformGET(string url, string parameters)
        {
            HttpClient client;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
                HttpResponseMessage response = client.GetAsync(parameters).Result;  // TODO - FIX - Blocking call! Program will wait here until a response is received or a timeout occurs.
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
    }
}