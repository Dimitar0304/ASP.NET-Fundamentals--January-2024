using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;


namespace TaskBoardApp.Controllers
{
    public class TaskController: Controller
    {
        private TaskBoardDbContext db;
        public TaskController(TaskBoardDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TaskFormModel()
            {
                Boards = GetBoards()
            };
            return  View(model);
        }

        private IEnumerable<TaskBoardModel> GetBoards()
        {
            return db.Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!GetBoards().Any(b=>b.Id==model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board doesn't exist");
            }
            string currentUser = GetUserId();
            if (ModelState.IsValid)
            {
                model.Boards = GetBoards();
                return View(model);
            }
            var data = new Data.Models.Task()
            {
                Title = model.Title,
                Description = model.Description,
                OwnerId = currentUser,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
            };
            await db.Tasks.AddAsync(data);
            await db.SaveChangesAsync();
            var boards = db.Boards;
            return RedirectToAction("All");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
