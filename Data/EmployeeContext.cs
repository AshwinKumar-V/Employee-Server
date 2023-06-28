using Employee_Server.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace Employee_Server.Data
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Designation> Designations { get; set; } = null!;
        public DbSet<WorkingHour> WorkingHours { get; set; } = null!;
        public DbSet<PaymentRule> PaymentRules { get; set; } = null!;
    }
}
