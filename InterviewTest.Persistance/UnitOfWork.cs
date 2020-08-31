using InterviewTest.Contracts.Repository;
using InterviewTest.Contracts.UnitOfWork;
using InterviewTest.DataAccess;
using InterviewTest.Repository.Repositories;
using System;

namespace InterviewTest.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InterviewTestContext _context;
        public UnitOfWork(InterviewTestContext context)
        {
            _context = context;
            Leaves = new LeaveRepository(_context);
            LeaveTypes = new LeaveTypeRepository(_context);
        }

        public ILeaveRepository Leaves { get; }

        public ILeaveTypeRepository LeaveTypes { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
