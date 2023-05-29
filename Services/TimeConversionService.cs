using System;

namespace TimeZoneConverterAPI.Services
{
    public class TimeConversionService
    {
        public DateTime ConvertUtcToTimeZone(string timeZone)
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);
        }
    }
}
