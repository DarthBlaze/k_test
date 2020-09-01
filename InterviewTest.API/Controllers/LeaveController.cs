using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewTest.API.DTOs;
using InterviewTest.Contracts.Managers;
using InterviewTest.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveManager LeaveManager;
        private readonly IMapper Mapper;
        private readonly ILogger<LeaveController> Logger;

        public LeaveController(ILeaveManager leaveManager, IMapper mapper, ILogger<LeaveController> logger)
        {
            LeaveManager = leaveManager;
            Mapper = mapper;
            Logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult GetLeaves()
        {
            return Ok(Mapper.Map<IEnumerable<LeaveDTO>>(LeaveManager.GetAllLeaves()));
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetLeave(int id)
        {
            var leave = Mapper.Map<LeaveDTO>(LeaveManager.GetLeave(id));
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(leave);
        }

        [HttpPost("[action]")]
        public IActionResult NewLeave([FromBody] LeaveDTO leave)
        {
            try
            {
                if (LeaveManager.NewLeave(Mapper.Map<Leave>(leave), out string message))
                {
                    return StatusCode(StatusCodes.Status201Created, message);
                }

                return StatusCode(StatusCodes.Status409Conflict, message);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Error while creating leave");
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateLeave(int id, [FromBody] LeaveDTO leave)
        {
            try
            {
                leave.Id = id;
                Leave updatedLeave = LeaveManager.UpdateLeave(Mapper.Map<Leave>(leave), out string message);
                if (updatedLeave != null)
                {
                    return Ok(Mapper.Map<LeaveDTO>(updatedLeave));
                }

                return StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Error while updating leave");
                return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteLeave(int id)
        {
            try
            {
                if (LeaveManager.DeleteLeave(id, out string message))
                {
                    return Ok(message);
                }

                return StatusCode(StatusCodes.Status304NotModified, message);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Error while deleting leave");
                return StatusCode(500, exception.Message);
            }
        }
    }
}
