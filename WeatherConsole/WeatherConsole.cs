using System;
using TDDWeather;

class WeatherConsole
{
    private const double LATITUDE = 36.0957;
    private const double LONGITUDE = -79.4378;
    
    private static IHandlersProvider handlersProvider;

    public static void Main(string [] args)
    {
        ICredentialsLoader credentialsLoader = new MockCredentialsLoader();
        IApiOperation apiOperation = new MockApiOperation(credentialsLoader.GetApiKey());
        handlersProvider = new TestHandlersProvider();
        
        int selection;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Weather Lookup");
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine("C. Current conditions for Burlington");
            Console.WriteLine("L. Location for Burlington");
            Console.WriteLine("X. Exit");
            Console.Write("Choice? ");

            selection = Console.Read();
            Console.WriteLine();

            if (selection == 'L' || selection == 'l')
            {
                HandleLocation();
            } 
            else if (selection == 'C' || selection == 'c')
            {
                HandleCurrentConditions();
            }

        } while (selection != 'X' && selection != 'x');
    }

    private static void HandleLocation()
    {
        Console.WriteLine("Location for Burlington...");
        var location = handlersProvider.GetLocationQueryHandler().GetLocationFor("Burlington", "US", "NC");
        if (location == null)
        {
            Console.WriteLine("UNABLE TO GET LOCATION INFO");
            return;
        }
        
        Console.WriteLine("  Latitude: " + location.GetLatitude());
        Console.WriteLine("  Longitude: " + location.GetLongitude());
    }

    public static void HandleCurrentConditions()
    {
        Console.WriteLine("Conditions for Burlington...");
        var conditions = handlersProvider.GetCurrentConditionsQueryHandler().GetCurrentConditionsFor(LATITUDE, LONGITUDE);
        if (conditions == null)
        {
            Console.WriteLine("UNABLE TO GET CONDITIONS INFO");
            return;
        }
        
        Console.WriteLine("  Condition: " + conditions.GetConditionCode());
        Console.WriteLine("  Description: " + conditions.GetConditionDescription());
        Console.WriteLine("  Cloud coverage %: " + conditions.GetCloudCoveragePercent());
        Console.WriteLine("  Temp in C: " + conditions.GetTemperatureInCelsius());
        Console.WriteLine("  Max Temp in C: " + conditions.GetMaximumTemperatureInCelsius());
        Console.WriteLine("  Min Temp in C: " + conditions.GetMinimumTemperatureInCelsius());
        Console.WriteLine("  Humidity %: " + conditions.GetHumidityInPercent());
        Console.WriteLine("  Visibiity in ft: " + conditions.GetVisibilityInFeet());
        Console.WriteLine("  Wind speed in kt: " + conditions.GetWindSpeedInKnots());
        Console.WriteLine("  Wind direction: " + conditions.GetWindDirectionInDegrees());
        Console.WriteLine("  Sunrise UTC: " + conditions.GetSunriseTime());
        Console.WriteLine("  Sunset UTC: " + conditions.GetSunsetTime());
      
    }
}