using HomeMetrics.Collector.DAL.Models;
using HomeMetrics.Collector.DAL.Repositories;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeMetrics.Collector.API.Controllers
{
    [Route("api/sensor")]
    public class SensorController : APIController
    {
        private readonly ILogger<SensorController> _log;
        private readonly ISensorRepository _sensors;

        public SensorController(ILogger<SensorController> log, ISensorRepository sensors)
        {
            _log = log;
            _sensors = sensors;
        }

        [HttpPost]
        public IActionResult Add([FromBody]dynamic sensor)
        {
            var name = (string) sensor.Name;
            _log.LogInformation(name);

            var newSensor = new Sensor
            {
                Name = (string)sensor.Name
            };

            _log.LogInformation(newSensor.Id.ToString());
            _sensors.Add(newSensor);

            return Created("api/reading/" + newSensor.Id);
        }
    }
}