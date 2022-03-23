namespace TDDWeather
{
    public interface ICurrentConditionsQueryHandler
    {
        ICurrentConditions GetCurrentConditionsFor(double latitude, double longitude);
    }
}