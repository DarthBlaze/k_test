using Microsoft.EntityFrameworkCore;
using System;

namespace InterviewTest.DataAccess
{
    public class InterviewTestContext : DbContext
    {
        public InterviewTestContext (DbContextOptions<InterviewTestContext> options): base(options)
        {

        }
    }
}
