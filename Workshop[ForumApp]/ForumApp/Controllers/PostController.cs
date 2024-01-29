using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        public readonly IPostService postService;
        public PostController(IPostService _postService)
        {
            postService = _postService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await postService.AllPostAsync();
            if (models != null)
            {
                return View(models);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostViewModel();
            return  View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                await postService.AddAsync(model);
                var models = await postService.AllPostAsync();
                return RedirectToAction("Index", models);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await postService.GetByIdAsync(id);

            return View(new PostViewModel()
            {
                Title = entity.Title,
                Content = entity.Content
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {

            await postService.UpdateAsync(model);
            var models = await postService.AllPostAsync();
            return RedirectToAction("Index", models);


        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await postService.GetByIdAsync(id);
            await postService.DeleteAsync(entity.Id);
            var models = await postService.AllPostAsync();
            return View("Index", models);
        }

    }
}
