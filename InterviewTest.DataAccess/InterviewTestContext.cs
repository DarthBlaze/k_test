using InterviewTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InterviewTest.DataAccess
{
    public class InterviewTestContext : DbContext
    {
        public InterviewTestContext (DbContextOptions<InterviewTestContext> options): base(options)
        {

        }

        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
