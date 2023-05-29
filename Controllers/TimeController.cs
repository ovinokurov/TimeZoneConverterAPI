using Microsoft.AspNetCore.Mvc;
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
