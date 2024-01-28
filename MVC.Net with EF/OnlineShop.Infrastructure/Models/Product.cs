using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Models
{
    public class Product
    {
        [Key]
        [Comment("Product Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Comment("Product Name")]
        public string ProductName { get; set; } = null!;
        [Required]
        [Comment("Product price")]
        public decimal Price { get; set; }

    }
}
