using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class OrderItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int PartId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal ItemPrice { get; set; }
    }

}



