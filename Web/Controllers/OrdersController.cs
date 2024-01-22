//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Web.Data;
//using Web.Models;

//[ApiController]
//[Route("api/[controller]")]
//public class OrdersController : ControllerBase
//{
//    private readonly SDbContext _context;

//    public OrdersController(SDbContext context)
//    {
//        _context = context;
//    }

//    [HttpGet]
//    public ActionResult<IEnumerable<Order>> GetOrders()
//    {
//        var orders = _context.Orders.Include(o => o.Customers).Include(o => o.Employee).ToList();
//        return Ok(orders);
//    }

//    [HttpGet("{id}")]
//    public ActionResult<Order> GetOrder(int id)
//    {
//        var order = _context.Orders.Include(o => o.Customers).Include(o => o.Employee).FirstOrDefault(o => o.Id == id);

//        if (order == null)
//        {
//            return NotFound();
//        }

//        return Ok(order);
//    }

//    [HttpPost]
//    public ActionResult<Order> PostOrder(Order order)
//    {
//        _context.Orders.Add(order);
//        _context.SaveChanges();

//        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
//    }

//    [HttpPut("{id}")]
//    public IActionResult PutOrder(int id, Order order)
//    {
//        if (id != order.Id)
//        {
//            return BadRequest();
//        }

//        _context.Entry(order).State = EntityState.Modified;
//        _context.SaveChanges();

//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public ActionResult<Order> DeleteOrder(int id)
//    {
//        var order = _context.Orders.Find(id);

//        if (order == null)
//        {
//            return NotFound();
//        }

//        _context.Orders.Remove(order);
//        _context.SaveChanges();

//        return Ok(order);
//    }
//}