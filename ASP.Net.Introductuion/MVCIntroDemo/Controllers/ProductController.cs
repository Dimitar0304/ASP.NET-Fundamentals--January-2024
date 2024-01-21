using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.ViewModels;
using System.Text;
using System.Text.Json;
using System.IO;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEnumerable<ProductModel> products = new List<ProductModel>
        {
            new ProductModel()
            {
                Id = 1,
                Name = "Cheese",
                Price =15
            },
            new ProductModel()
            {
                Id=2,
                Name = "Ham",
                Price=20
            },
            new ProductModel()
            {
                Id=3,
                Name = "Bread",
                Price =2
            }
        };

        [ActionName("My-Products")]
        public IActionResult AllProducts(string keyword)
        {
            List<ProductModel> matches = new List<ProductModel>();
            if (keyword!=null)
            {
                matches = products
                    .Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
            }
            if (keyword==null)
            {
                return View("AllProducts", products);
            }
            return View("AllProducts",matches);
        }
        public IActionResult ProductById(int id)
        {
            var model = products.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        public IActionResult AllProductsToJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }
        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"{product.Id} {product.Name} {product.Price}");
            }
            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");


        }
    }
}
