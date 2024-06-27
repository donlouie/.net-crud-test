using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    // dtg: localhost:xxx/api/
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* dtg: Get all employees */
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var allEmployees = await dbContext.Employees.ToListAsync();

            return Ok(allEmployees);
        }

        /* dtg: Get employee by id */
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        /* dtg: Add employee */
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            await dbContext.SaveChangesAsync();

            return Ok(employeeEntity);
        }

        /* dtg: Update employee by id */
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if(employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();

            return Ok(employee);
        }

        /* dtg: Delete employee by id */
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if(employee is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
