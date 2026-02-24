using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string? FullName { get; set; }

        public string? City { get; set; }

        public int Marks { get; set; }
    }
}