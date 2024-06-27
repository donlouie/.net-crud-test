using System.Security.Cryptography.X509Certificates;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        // dtg: Guid is used as the primary key
        public Guid Id { get; set; }
        // dtg: Required attribute is used to make sure that the Name and Email are required
        public required string Name { get; set; }
        public  required string Email { get; set; }
        // dtg: We make optional by using the ? operator <string?>
        public string? Phone { get; set; }
        public decimal Salary { get; set; }

    }
}

/*
 ** dtg:
 ** Explanation: This entity will have a primary key as entity and will have the condition of the 
 ** employee that will be added to the database.
 ** 
 **/