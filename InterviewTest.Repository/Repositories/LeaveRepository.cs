using InterviewTest.Contracts.Repository;
using InterviewTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Repository.Repositories
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {
        public LeaveRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get Leave entity using id key
        /// </summary>
        /// <param name="id">The key id of the entity to get</param>
        /// <returns>The Leave which key was provided</returns>
        public Leave GetLeave(int id) => Context.Set<Leave>()
                .Where(leave => leave.Id == id)
                .Include(leave => leave.LeaveType)
                .FirstOrDefault();

        /// <summary>
        /// Gets a list of all Leaves
        /// </summary>
        /// <returns>List of all Leaves</returns>
        public IEnumerable<Leave> GetAllLeaves() => Context.Set<Leave>()
                .Include(leave => leave.LeaveType)
                .OrderByDescending(leave => leave.LeaveDate)
                .ToList();
    }
}
