using InterviewTest.Contracts.Repository;
using InterviewTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewTest.Repository.Repositories
{
    public class LeaveTypeRepository : Repository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(DbContext context) : base(context)
        {
        }

        public LeaveType GetLeaveType(int id) => Context.Set<LeaveType>()
                .Where(leaveType => leaveType.Id == id)
                .FirstOrDefault();
    }
}