using System;
using System.ComponentModel.DataAnnotations;


namespace Web.Models
{
    public class Customers
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Phonenum { get; set; }
    }

}
