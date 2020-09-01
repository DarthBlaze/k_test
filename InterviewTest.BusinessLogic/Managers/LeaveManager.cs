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
            try
            {
                UnitOfWork.Leaves.Add(leave);
                message = "Leave registered succesfully";
                return true;    
            }
            catch (Exception ex)
            {

                message = ex.Message;
                return false;
            }
        }
    }
}
