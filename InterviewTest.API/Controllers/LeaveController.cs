using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveController : ControllerBase
    {
        
        private readonly ILogger<LeaveController> _logger;

        public LeaveController(ILogger<LeaveController> logger)
        {
            _logger = logger;
        }        
    }
}
