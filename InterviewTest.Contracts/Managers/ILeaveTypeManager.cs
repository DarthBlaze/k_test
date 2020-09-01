using InterviewTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.Contracts.Managers
{
    public interface ILeaveTypeManager
    {
        LeaveType GetLeaveType(int leaveTypeId);

        IEnumerable<LeaveType> GetAllLeaveTypes();
    }
}
 