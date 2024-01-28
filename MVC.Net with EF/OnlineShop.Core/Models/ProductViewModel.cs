using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage =UserErrorMessages.RequiredError)]
        [StringLength(100,MinimumLength =2,ErrorMessage =UserErrorMessages.StringLenghtError)]
        [Comment("Product Name")]
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage =UserErrorMessages.RequiredError)]
        [Comment("Product price")]
        public decimal Price { get; set; }
    }
}
