using OnlineShop.Core.Models;
using OnlineShop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Contracts
{
    public interface IProductService
    {
        public Task AddAsync(ProductViewModel model);
        public Task UpdateAsync(ProductViewModel model);
        public Task DeleteAsync(int id);
        public Task<ProductViewModel> GetByIdAsync(int id);
        public Task<IEnumerable<ProductViewModel>> GetAllAsync();
    }
}
