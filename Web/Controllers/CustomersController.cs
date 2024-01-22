using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Data;
using Web.Models;


[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly SDbContext _context;

    public CustomersController(SDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customers>> GetCustomers()
    {
        var customers = _context.Customers.ToList();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public ActionResult<Customers> GetCustomer(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customers> PostCustomer(Customers customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult PutCustomer(int id, Customers customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }

        _context.Entry(customer).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<Customers> DeleteCustomer(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        _context.SaveChanges();

        return Ok(customer);
    }
}
