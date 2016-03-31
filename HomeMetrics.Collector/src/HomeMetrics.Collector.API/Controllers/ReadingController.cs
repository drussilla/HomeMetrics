using System;
using HomeMetrics.Collector.DAL.Models;
using HomeMetrics.Collector.DAL.Repositories;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeMetrics.Collector.API.Controllers
{
    [Route("api/reading")]
    public class ReadingController : APIController
    {
        private readonly ILogger<ReadingController> _log;
        private readonly IReadingRepository _readings;

        public ReadingController(ILogger<ReadingController> log, IReadingRepository readings)
        {
            _log = log;
            _readings = readings;
        }

        public IActionResult GetAll()
        {
            return Ok(_readings.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody]dynamic reading)
        {
            var data = (string) reading.Data;
            _log.LogInformation(data);

            var newReading = new Reading
            {
                Data = (float) reading.Data,
                SensorId = (Guid) reading.SensorId,
                CollectedDateTime = (DateTime) reading.CollectedDateTime,
                CreatedDateTime = DateTime.Now
            };

            _readings.Add(newReading);
            return Created("api/reading/" + newReading.Id);
        }
    }
}