using System.ComponentModel.DataAnnotations;

namespace Feb25_EmployeeMVC.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Dept { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}