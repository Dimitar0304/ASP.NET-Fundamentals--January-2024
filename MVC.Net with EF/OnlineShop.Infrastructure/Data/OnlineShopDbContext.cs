using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data
{
    public class OnlineShopDbContext:DbContext
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext>options):base(options) 
        {
            
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductNote> ProductNotes { get; set; } = null!;
    }
}
