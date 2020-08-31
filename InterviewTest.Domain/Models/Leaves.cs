using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Domain.Models
{
    public class Leave: BaseModel
    {
        [StringLength(50,ErrorMessage ="* The employee name cannot be longer than 50 characters.")]
        [Required]
        public string EmployeeName { get; set; }
        [StringLength(50, ErrorMessage = "* The employee surname cannot be longer than 50 characters.")]
        [Required]
        public string EmployeeSurname { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        [Required]
        public DateTime LeaveDate { get; set; }

    }
}
