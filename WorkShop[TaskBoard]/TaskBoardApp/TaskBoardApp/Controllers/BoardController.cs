using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class BoardController:Controller
    {
        private TaskBoardDbContext db;
        public BoardController(TaskBoardDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> All()
        {
            var boards =  await db.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })



                }).ToListAsync();
              return View(boards);
             }
        }
    }

