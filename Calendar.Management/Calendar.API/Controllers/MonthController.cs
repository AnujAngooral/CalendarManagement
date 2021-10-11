using Calendar.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthController : ControllerBase
    {
        private readonly ILogger<MonthController> _logger;
        private readonly IMonthService _monthService;
        /// <summary>
        /// Initialise the Month Controller with logger and month service.
        /// </summary>
        /// <param name="logger"> logger service to log messages</param>
        /// <param name="monthService"></param>
        public MonthController(ILogger<MonthController> logger, IMonthService monthService)
        {
            _logger = logger;
            _monthService = monthService;
        }

        /// <summary>
        /// This method is used to get collection of months.
        /// </summary>
        /// <returns>Returns the collection of months. In case of any error, we throw back 500 
        /// internal server error
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("About to call the month service.");
            var result = await _monthService.GetAsync();

            if (result.IsSuccess)
            {
                return Ok(result.Months);
            }

            return StatusCode(500, "Internal Server Error");

        }

    }
}
