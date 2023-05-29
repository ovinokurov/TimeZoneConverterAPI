using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using TimeZoneConverterAPI.Services;

namespace TimeZoneConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly TimeConversionService _timeConversionService;

        public TimeController(TimeConversionService timeConversionService)
        {
            _timeConversionService = timeConversionService;
        }

        /// <summary>
        /// Retrieves the current date and time, converted to the user-specified time zone from Coordinated Universal Time (UTC).
        /// </summary>
        /// <remarks>
        /// This API endpoint requires a time zone parameter. The time zone parameter should be a valid Windows time zone identifier. Here are a few examples:
        /// <para> - "UTC": Coordinated Universal Time </para>
        /// <para> - "Pacific Standard Time": Pacific Time (US and Canada) </para>
        /// <para> - "Eastern Standard Time": Eastern Time (US and Canada) </para>
        /// <para> - "GMT Standard Time": Greenwich Mean Time (London) </para>
        /// <para> - "India Standard Time": India Standard Time </para>
        /// <para> - "Japan Standard Time": Japan Standard Time </para>
        /// <para>Please make sure to use the exact time zone identifier as per the examples above.</para>
        /// </remarks>
        /// <param name="timeZone">The Windows time zone identifier as a string.</param>
        /// <returns>A string representing the current date and time in the specified time zone.</returns>



        [HttpGet]
        public ActionResult<string> Get(string timeZone)
        {
            try
            {
                DateTime localDateTime = _timeConversionService.ConvertUtcToTimeZone(timeZone);
                return localDateTime.ToString();
            }
            catch (TimeZoneNotFoundException)
            {
                return NotFound($"Timezone '{timeZone}' not found.");
            }
            catch (InvalidTimeZoneException)
            {
                return BadRequest($"Timezone '{timeZone}' is invalid.");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
