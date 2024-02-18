using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SeminarHub.Data;
using SeminarHub.Data.Migrations.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    /// <summary>
    /// Seminar Controller class
    /// </summary>
    [Authorize]

    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;
        /// <summary>
        /// Dependency injection pattern
        /// </summary>
        /// <param name="_context"></param>
        public SeminarController(SeminarHubDbContext _context)
        {
            data = _context;
        }
        /// <summary>
        /// Add method for adding Seminar to app
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarViewModel();

            model.Categories = await GetCategories();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarViewModel model)
        {
           
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }
            var dateTime = DateTime.Parse(model.DateAndTime);
            if (!DateTime.TryParseExact(
               model.DateAndTime,
               DataConstants.SeminarDateFormat,
               CultureInfo.InvariantCulture,
               DateTimeStyles.None,
               out dateTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.SeminarDateFormat}");
            }

            string userId = GetUserId();

            var entity = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                Duration = model.Duration,
                DateAndTime =DateTime.Parse(model.DateAndTime),
                CategoryId = model.CategoryId,
                OrganizerId = userId

            };
            await data.Seminars.AddAsync(entity);
            await data.SaveChangesAsync();
            return RedirectToAction("All");
        }
        /// <summary>
        /// Method for getting all Seminars
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            var userId = GetUserId();

            var models = await data.Seminars
                .Where(s => !s.SeminarsParticipants
                .Contains(new SeminarParticipant()
                {
                    SeminarId = s.Id,
                    ParticipantId = userId
                }))
                .Select(s => new SeminarAllViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.SeminarDateFormat),
                    Category = s.Category.Name,
                    Organizer = s.Organizer.UserName

                })
                .AsNoTracking()
                .ToListAsync();

            return View(models);
        }
        /// <summary>
        /// Method for join in current Seminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Joined(int id)
        {
            var s = data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != string.Empty)
            {
                var sp = new SeminarParticipant()
                {
                    SeminarId = id,
                    ParticipantId = userId
                };
                await data.SeminarsParticipants.AddAsync(sp);
                await data.SaveChangesAsync();
            }
            return RedirectToAction("Joined");

        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();



            var models = await data.Seminars
                .Where(s => s.SeminarsParticipants.Any(ep => ep.ParticipantId == userId))
                .Select(s => new SeminarAllViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.SeminarDateFormat),
                    Category = s.Category.Name,
                    Organizer = s.Organizer.UserName
                })
                .AsNoTracking()
                .ToListAsync();



            if (models == null)
            {

                return View();
            }

            return View(models);
        }
        /// <summary>
        /// Method for Edit current Seminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await data.Seminars
                .Where(s => s.Id == id)
                .Select(s => new SeminarViewModel()
                {
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Details = s.Details,
                    CategoryId = s.CategoryId,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.SeminarDateFormat),
                    Duration = s.Duration,

                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            model.Categories = await GetCategories();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SeminarViewModel model, int id)
        {
            var e = data.Seminars.Find(id);

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }
            var dateTime = DateTime.Parse(model.DateAndTime);
            if (!DateTime.TryParseExact(
               model.DateAndTime,
               DataConstants.SeminarDateFormat,
               CultureInfo.InvariantCulture,
               DateTimeStyles.None,
               out dateTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.SeminarDateFormat}");
            }

            string userId = GetUserId();

            e.Topic = model.Topic;
            e.Lecturer = model.Lecturer;
            e.Details = model.Details;
            e.Duration = model.Duration;
            e.DateAndTime = dateTime;
            e.CategoryId = model.CategoryId;
            e.OrganizerId = userId;




            await data.SaveChangesAsync();
            return RedirectToAction("All");
        }
        /// <summary>
        /// Method for leave the joined seminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Leave(int id)
        {

            string userId = GetUserId();
            var sp = await data.SeminarsParticipants
                .FirstOrDefaultAsync(s => s.SeminarId == id && s.ParticipantId == userId);
            if (sp != null)
            {
                data.SeminarsParticipants.Remove(sp);
                await data.SaveChangesAsync();
            }
                return RedirectToAction("Joined");
            
        }
        /// <summary>
        /// Method for details for chosen seminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Seminars
                .Where(s => s.Id == id)
                .Select(s => new SeminarAllViewModel()
                {
                    Topic = s.Topic,
                    Details = s.Details,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.SeminarDateFormat),
                    Duration = s.Duration,
                    Organizer = s.Organizer.UserName
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var s = data.Seminars
                .Select(s => new SeminarAllViewModel()
                {
                    Id = id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.SeminarDateFormat)
                })
                .FirstOrDefaultAsync();
           
            return View(s);
            
        }
        [HttpPost]
        public IActionResult Delete(SeminarAllViewModel model)
        {
            var s = data.Seminars.Find(model.Id);
           if (data.SeminarsParticipants.Any(sp => sp.SeminarId == s.Id))
            {
                var models = data.SeminarsParticipants
                    .Where(sp => sp.SeminarId == model.Id)
                    .ToList();
                data.SeminarsParticipants.RemoveRange(models);
            }
            data.Seminars.Remove(s);
            return RedirectToAction("All");
        }
        
        /// <summary>
        /// Method for getting categories to seminarViewModel
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private async Task<List<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,

                })
                .AsNoTracking()
                .ToListAsync();
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
