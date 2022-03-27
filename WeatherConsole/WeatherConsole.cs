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
        // handlersProvider = new TestHandlersProvider();
        handlersProvider = new OwmHandlersProvider(new HttpApiOperation(), new XMLCredentialsLoader(@"C:\Code\CSharp\TDDWeather\WeatherConsole\OpenWeatherMap.credentials"));
        
        var selection = ' ';
        do
        {
            Console.WriteLine();
            Console.WriteLine("Weather Lookup");
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine("C. Current conditions for Burlington");
            Console.WriteLine("F. Future conditions for Burlington");
            Console.WriteLine("L. Location for Burlington");
            Console.WriteLine("X. Exit");
            Console.Write("Choice? ");

            selection = GetChoice();
            Console.WriteLine();

            if (selection == 'L')
            {
                HandleLocation();
            } 
            else if (selection == 'F')
            {
                HandleFutureConditions();
            }
            else if (selection == 'C')
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

    private static void HandleCurrentConditions()
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
    
    private static void HandleFutureConditions()
    {
        Console.WriteLine("Future conditions for Burlington...");
        var conditions = handlersProvider.GetFutureConditionsQueryHandler().GetFutureConditionsFor(LATITUDE, LONGITUDE);
        if (conditions == null)
        {
            Console.WriteLine("UNABLE TO GET CONDITIONS INFO");
            return;
        }

        foreach (var futureCondition in conditions)
        {
            Console.WriteLine("  Day: " + futureCondition.GetDayOfWeek());
            Console.WriteLine("  Condition: " + futureCondition.GetConditionCode());
            Console.WriteLine("  Max temp in C: " + futureCondition.GetMaximumTemperatureInCelsius());
            Console.WriteLine("  Min temp in C: " + futureCondition.GetMinimumTemperatureInCelsius());
            Console.WriteLine("  Max cloud coverage %: " + futureCondition.GetMaximumCloudCoveragePercent());
            Console.WriteLine("  Min cloud coverage %: " + futureCondition.GetMinimumCloudCoveragePercent());
            Console.WriteLine();
        }
    }

    private static char GetChoice()
    {
        var selection = Console.ReadLine();
        if (selection.Length == 0)
        {
            return ' ';
        }

        return selection.ToUpper()[0];
    }
}