using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Core.Common;

namespace OnlineShop.Core.Models
{
    public class ProductNoteViewModel
    {
        [Required(ErrorMessage =UserErrorMessages.RequiredError)]
        [Comment("Product quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage =UserErrorMessages.RequiredError)]
        [ForeignKey(nameof(Product))]
        [Comment("product identifier")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
