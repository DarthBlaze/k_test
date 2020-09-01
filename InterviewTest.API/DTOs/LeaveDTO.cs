using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.API.DTOs
{
    public class LeaveDTO
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}
