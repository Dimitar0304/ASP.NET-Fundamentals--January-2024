using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Models
{
    public class ProductNote
    {
        [Key]
        [Comment("Product note identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Product quantity")]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        [Comment("product identifier")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
