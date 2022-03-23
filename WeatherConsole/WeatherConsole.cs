using System;
using TDDWeather;

class WeatherConsole
{
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
            Console.WriteLine("L. Location for Burlington");
            Console.WriteLine("X. Exit");
            Console.Write("Choice? ");

            selection = Console.Read();
            Console.WriteLine();

            if (selection == 'L' || selection == 'l')
            {
                HandleLocation();
            }

        } while (selection != 'X' && selection != 'x');
    }

    private static void HandleLocation()
    {
        Console.WriteLine("Location for Burlington...");
        ILocation location = handlersProvider.GetLocationQueryHandler().GetLocationFor("Burlington", "US", "NC");
        if (location == null)
        {
            Console.WriteLine("UNABLE TO GET LOCATION INFO");
            return;
        }
        
        Console.WriteLine("  Latitude: " + location.GetLatitude());
        Console.WriteLine("  Longitude: " + location.GetLongitude());
    }
}