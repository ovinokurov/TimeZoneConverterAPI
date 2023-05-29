using System;
using TimeZoneConverterAPI.Interfaces;

namespace TimeZoneConverterAPI.Services
{
    public class TimeConversionService : ITimeConversionService
    {
        public string ConvertUtcToTimeZone(string timeZone)
        {
            // Implementation logic goes here
            // Convert the UTC time to the specified time zone and return the result

            // Example implementation using TimeZoneConverter library
            var utcTime = DateTime.UtcNow;
            var convertedTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.FindSystemTimeZoneById(timeZone));

            return convertedTime.ToString();
        }
    }
}
