using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public class ProductService : IProductService
    {
        private OnlineShopDbContext context;
        public ProductService(OnlineShopDbContext _context)
        {
            context = _context;
        }
        public  async Task  AddAsync(ProductViewModel model)
        {
            if (model == null) throw new ArgumentNullException();
            var dataModel = new Product()
            {
                Id = model.Id,
                ProductName = model.ProductName,
                Price = model.Price,
            };
            await context.Products.AddAsync(dataModel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!context.Products.Any(p => p.Id == id)) throw new ArgumentException();
            Product modelToDelete =  await context.Products.FirstAsync(p=>p.Id==id);   
             context.Products.Remove(modelToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return await context.Products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
            }).ToListAsync();
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var entity = await context.Products.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid product");
            }

            return new ProductViewModel()
            {
                Id = id,
                ProductName = entity.ProductName
            };
        }

        public async Task UpdateAsync(ProductViewModel model)
        {
            if (model == null) throw new ArgumentNullException();
            Product modelToUpdate = await context.Products.FirstAsync(p=>p.Id==model.Id);
            modelToUpdate.ProductName=model.ProductName;
            modelToUpdate.Price=model.Price;
             context.Products.Update(modelToUpdate);
            await context.SaveChangesAsync();
        }
    }
}
