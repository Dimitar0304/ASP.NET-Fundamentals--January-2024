using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    /// <summary>
    /// Ad controller
    /// </summary>
    public class AdController : Controller
    {
        /// <summary>
        /// Database 
        /// </summary>
        private readonly BazarDbContext data;
        /// <summary>
        /// Dependency injection context
        /// </summary>
        /// <param name="_context"></param>
        public AdController(BazarDbContext _context)
        {
            data = _context;
        }
        /// <summary>
        /// Method for shows all Ads
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            if (User.Identity.IsAuthenticated)
            {
                var models = await data.Ads
                    .Select(a => new AdViewModel()
                    {
                        Name = a.Name,
                        Description = a.Description,
                        Category = a.Category.Name,
                        CreatedOn = a.CreatedOn.ToString(DataConstants.DataFromat),
                        Owner = a.Owner.UserName,
                        OwnerEmail = a.Owner.Email,
                        Price = a.Price,
                        ImageUrl = a.ImageUrl

                    })
                    .AsNoTracking()
                    .ToListAsync();
                return View(models);
            }
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Method for add ad to app
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public async Task<IActionResult> Add()
        {
            var model = new AdFormViewModel();
            model.Categories = await GetCategories();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }
            var entityCategory = model.Categories
                .Select(c => new Category()
                {
                    Id = c.Id,
                    Name = c.Name

                })
                .FirstOrDefault(c => c.Id == model.CategoryId);
            string userId = GetUserId();
            var entity = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                OwnerId = userId,
                Owner = data.Users.Find(userId)

            };
            await data.Ads.AddAsync(entity);
            await data.SaveChangesAsync();
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Cart(int id)
        {
            var ad = data.Ads.FirstOrDefaultAsync(a => a.Id == id);

            string userId = GetUserId();

            if (ad != null)
            {
                var entity = new AdBuyer()
                {
                    BuyerId = userId,
                    AdId = id
                };
            }
            var models = await data.Ads
               .Select(a => new AdViewModel()
               {
                   Name = a.Name,
                   Description = a.Description,
                   Category = a.Category.Name,
                   CreatedOn = a.CreatedOn.ToString(DataConstants.DataFromat),
                   Owner = a.Owner.UserName,
                   OwnerEmail = a.Owner.Email,
                   Price = a.Price,
                   ImageUrl = a.ImageUrl

               })
               .AsNoTracking()
               .ToListAsync();
            return RedirectToAction("All", models);
        }



        /// <summary>
        /// Private method for getting categories 
        /// </summary>
        /// <returns></returns>
        private async Task<List<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
        /// <summary>
        /// Private method for getting current User
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
