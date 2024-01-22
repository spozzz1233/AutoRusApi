using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web.Data;
using Web.Models;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly SDbContext _context;

    public EmployeesController(SDbContext context)
    {
        _context = context;
    }

    // GET: api/Employees
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        var employees = _context.Employees.ToList();
        return Ok(employees);
    }

    // GET: api/Employees/5
    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployee(int id)
    {
        var employee = _context.Employees.Find(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    // POST: api/Employees
    [HttpPost]
    public ActionResult<Employee> PostEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
    }

    // PUT: api/Employees/5
    [HttpPut("{id}")]
    public IActionResult PutEmployee(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }

        _context.Entry(employee).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public ActionResult<Employee> DeleteEmployee(int id)
    {
        var employee = _context.Employees.Find(id);

        if (employee == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employee);
        _context.SaveChanges();

        return Ok(employee);
    }
}
