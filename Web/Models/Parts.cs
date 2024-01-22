using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Parts
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PartName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
    }

}
