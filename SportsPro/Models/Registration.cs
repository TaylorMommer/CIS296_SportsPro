using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace SportsPro.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }
        public string errorMessage { get; set; }    
    }
}
