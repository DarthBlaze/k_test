using InterviewTest.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.Contracts.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ILeaveRepository Leaves { get; }
        ILeaveTypeRepository LeaveTypes { get; }
    }
}
