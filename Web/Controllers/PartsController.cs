using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Data;
using Web.Models;

[ApiController]
[Route("api/[controller]")]
public class PartsController : ControllerBase
{
    private readonly SDbContext _context;

    public PartsController(SDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Parts>> GetParts()
    {
        var parts = _context.Parts.ToList();
        return Ok(parts);
    }

    [HttpGet("{id}")]
    public ActionResult<Parts> GetPart(int id)
    {
        var part = _context.Parts.Find(id);

        if (part == null)
        {
            return NotFound();
        }

        return Ok(part);
    }

    [HttpPost]
    public ActionResult<Parts> PostPart(Parts part)
    {
        _context.Parts.Add(part);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPart), new { id = part.Id }, part);
    }

    [HttpPut("{id}")]
    public IActionResult PutPart(int id, Parts part)
    {
        if (id != part.Id)
        {
            return BadRequest();
        }

        _context.Entry(part).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<Parts> DeletePart(int id)
    {
        var part = _context.Parts.Find(id);

        if (part == null)
        {
            return NotFound();
        }

        _context.Parts.Remove(part);
        _context.SaveChanges();

        return Ok(part);
    }
}
