using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private  IProductService productService;
        private int id = default(int);
       
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                 await productService.AddAsync(model);
               IEnumerable<ProductViewModel>  models = await productService.GetAllAsync();
                return View("Index",models);
            }
            return View(model);  
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductViewModel> models = await productService.GetAllAsync();
            return View( models);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await productService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await productService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
