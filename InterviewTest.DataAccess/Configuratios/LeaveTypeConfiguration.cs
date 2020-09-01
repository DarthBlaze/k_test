using InterviewTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.DataAccess.Configuratios
{
    class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData
            (
                new LeaveType
                {
                    Id = 1,
                    Description = "Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    Description = "Medical Procedure"
                },
                new LeaveType
                {
                    Id = 3,
                    Description = "Sickness"
                }
            );
        }
    }
}
