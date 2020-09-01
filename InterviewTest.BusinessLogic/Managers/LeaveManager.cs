using InterviewTest.Contracts.Managers;
using InterviewTest.Contracts.UnitOfWork;
using InterviewTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.BusinessLogic.Managers
{
    public class LeaveManager : ILeaveManager
    {
        private readonly IUnitOfWork UnitOfWork;
        public LeaveManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Leave> GetAllLeaves()
        {
            return UnitOfWork.Leaves.GetAllLeaves();
        }

        public Leave GetLeave(int leaveId)
        {
            return UnitOfWork.Leaves.GetLeave(leaveId);
        }

        public bool NewLeave(Leave leave, out string message)
        {
            UnitOfWork.Leaves.Add(leave);
            UnitOfWork.Complete();
            message = "Leave registered succesfully";
            return true;
        }

        public Leave UpdateLeave(Leave leave, out string message)
        {
            UnitOfWork.Leaves.Update(leave);
            UnitOfWork.Complete();
            message = "Leave updated sucessfully";
            return UnitOfWork.Leaves.Get(leave.Id);
        }

        public bool DeleteLeave(int leaveId, out string message)
        {
            var leaveToBeDeleted = UnitOfWork.Leaves.GetLeave(leaveId);
            if (leaveToBeDeleted == null)
            {
                message = "This leave does not exist";
                return false;
            }

            UnitOfWork.Leaves.Remove(leaveToBeDeleted);
            message = "Leave deleted successfully";
            return true;
        }
    }
}
