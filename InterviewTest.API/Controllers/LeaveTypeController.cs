using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewTest.API.DTOs;
using InterviewTest.Contracts.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeManager LeaveTypeManager;
        private readonly IMapper Mapper;
        private readonly ILogger<LeaveController> Logger;

        public LeaveTypeController(ILeaveTypeManager leaveTypeManager, IMapper mapper, ILogger<LeaveController> logger)
        {
            LeaveTypeManager = leaveTypeManager;
            Mapper = mapper;
            Logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult GetLeaveTypes()
        {
            return Ok(Mapper.Map<IEnumerable<LeaveTypeDTO>>(LeaveTypeManager.GetAllLeaveTypes()));
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetLeave(int id)
        {
            var leaveType = Mapper.Map<LeaveTypeDTO>(LeaveTypeManager.GetLeaveType(id));
            if (leaveType == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(leaveType);
        }
    }
}
