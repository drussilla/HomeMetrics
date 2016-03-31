using System;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeMetrics.Collector.API.Controllers
{
    [Route("api/reading")]
    public class ReadingController : ApiController
    {
        private ILogger<ReadingController> _log;

        public ReadingController(ILogger<ReadingController> log)
        {
            _log = log;
        }

        [HttpPost]
        public void Add([FromBody]dynamic reading)
        {
            var data = (string) reading.Data;
            _log.LogVerbose(data);
        }
    }
}