using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}

/*
 * dtg:
 * * Explanation: This class is used to create the database context for the application. It will be used to 
 * * create the database and the tables that will be used in the application. It is something that is required 
 * * by Entity Framework.
 * * 
 * * */
