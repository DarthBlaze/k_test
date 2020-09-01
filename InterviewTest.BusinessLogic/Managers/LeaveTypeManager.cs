using InterviewTest.Contracts.Managers;
using InterviewTest.Contracts.UnitOfWork;
using InterviewTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.BusinessLogic.Managers
{
    public class LeaveTypeManager : ILeaveTypeManager
    {
        private readonly IUnitOfWork UnitOfWork;

        public LeaveTypeManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<LeaveType> GetAllLeaveTypes()
        {
            return UnitOfWork.LeaveTypes.GetAllLeaveTypes();
        }

        public LeaveType GetLeaveType(int leaveTypeId)
        {
            return UnitOfWork.LeaveTypes.GetLeaveType(leaveTypeId);
        }
    }
}
