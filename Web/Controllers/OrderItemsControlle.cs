//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Web.Data;
//using Web.Models;

//[ApiController]
//[Route("api/[controller]")]
//public class OrderItemsController : ControllerBase
//{
//    private readonly SDbContext _context;

//    public OrderItemsController(SDbContext context)
//    {
//        _context = context;
//    }

//    [HttpGet]
//    public ActionResult<IEnumerable<OrderItem>> GetOrderItems()
//    {
//        var orderItems = _context.OrderItems.Include(oi => oi.Order).Include(oi => oi.Part).ToList();
//        return Ok(orderItems);
//    }

//    [HttpGet("{id}")]
//    public ActionResult<OrderItem> GetOrderItem(int id)
//    {
//        var orderItem = _context.OrderItems.Include(oi => oi.Order).Include(oi => oi.Part).FirstOrDefault(oi => oi.Id == id);

//        if (orderItem == null)
//        {
//            return NotFound();
//        }

//        return Ok(orderItem);
//    }

//    [HttpPost]
//    public ActionResult<OrderItem> PostOrderItem(OrderItem orderItem)
//    {
//        _context.OrderItems.Add(orderItem);
//        _context.SaveChanges();

//        return CreatedAtAction(nameof(GetOrderItem), new { id = orderItem.Id }, orderItem);
//    }

//    [HttpPut("{id}")]
//    public IActionResult PutOrderItem(int id, OrderItem orderItem)
//    {
//        if (id != orderItem.Id)
//        {
//            return BadRequest();
//        }

//        _context.Entry(orderItem).State = EntityState.Modified;
//        _context.SaveChanges();

//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public ActionResult<OrderItem> DeleteOrderItem(int id)
//    {
//        var orderItem = _context.OrderItems.Find(id);

//        if (orderItem == null)
//        {
//            return NotFound();
//        }

//        _context.OrderItems.Remove(orderItem);
//        _context.SaveChanges();

//        return Ok(orderItem);
//    }
//}
