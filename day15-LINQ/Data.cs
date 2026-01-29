using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; }
        public int DeptId { get; set; }
    }

    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}