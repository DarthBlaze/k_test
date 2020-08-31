using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Domain.Models
{
    public class LeaveType:BaseModel
    {
        [StringLength(150, ErrorMessage = "* The leave description cannot be longer than 150 characters.")]
        [Required]
        public string Description { get; set; }
    }
}