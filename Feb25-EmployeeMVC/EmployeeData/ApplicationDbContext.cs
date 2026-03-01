using Microsoft.EntityFrameworkCore;
using Feb25_EmployeeMVC.Models;

namespace Feb25_EmployeeMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}