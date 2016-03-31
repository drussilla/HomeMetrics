using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace HomeMetrics.Collector.API.Controllers
{
    public class APIController : Controller
    {
        protected IActionResult Created(string location)
        {
            return new CreatedResult(location, null);
        }

        protected IActionResult Error()
        {
            return new BadRequestResult();
        }

        protected IActionResult Error(IEnumerable<string> errorMessages)
        {
            return new BadRequestObjectResult(errorMessages);
        }

        protected IActionResult Error(string error)
        {
            return new BadRequestObjectResult(error);
        }

        protected IActionResult Unauthorized()
        {
            return new HttpUnauthorizedResult();
        }

        protected IActionResult NotFound()
        {
            return new HttpNotFoundResult();
        }

        protected IActionResult NotFound(object value)
        {
            return new HttpNotFoundObjectResult(value);
        }
    }
}