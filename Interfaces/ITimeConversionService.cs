namespace TimeZoneConverterAPI.Interfaces
{
    public interface ITimeConversionService
    {
        string ConvertUtcToTimeZone(string timeZone);
    }
}
