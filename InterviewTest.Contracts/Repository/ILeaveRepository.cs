using InterviewTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.Contracts.Repository
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        IEnumerable<Leave> GetAllLeaves();
        Leave GetLeave(int id);
    }
}
