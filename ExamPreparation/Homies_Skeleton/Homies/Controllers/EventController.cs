using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using Type = Homies.Data.Models.Type;

namespace Homies.Controllers
{

    [Authorize]
    public class EventController : Controller

    {
        private readonly HomiesDbContext data;
        public EventController(HomiesDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> All()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = GetUser();
                IEnumerable<EventViewModel> evens = await data.Events
                    .Where(e => !e.EventsParticipants
                    .Contains(new EventParticipant()
                    {
                        EventId = e.Id,
                        HelperId = userId
                    }))
                    .Select(e => new EventViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Type = e.Type.Name,
                        Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                        Organiser = GetUser()
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return View(evens);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Joined(int id)
        {
            var e = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }

            string userId = GetUser();

            if (userId != null)
            {
                var model = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = id,
                };
                await data.EventsParticipants.AddAsync(model);
                await data.SaveChangesAsync();
            }


            return RedirectToAction("All", "Event");

        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUser();


            var models = await data.Events
                .Where(e => e.EventsParticipants.Any(ep => ep.HelperId == userId))
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.Type.Name,
                    Start = e.Start.ToString(DataConstants.DateFormat)
                }).ToListAsync();


            if (models == null)
            {

                return View();
            }

            return View(models);
        }
        [HttpPost]
        public IActionResult Leave(int id)
        {
            string userId = GetUser();

            EventParticipant ep = data.EventsParticipants.First(ep => ep.EventId == id && ep.HelperId == userId);
            data.EventsParticipants.Remove(ep);
            data.SaveChanges();
            return RedirectToAction("Joined");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormModel();
            model.Types = await GetTypes();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState
                    .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState
                    .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            var entity = new Event()
            {
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                OrganiserId = GetUser(),
                TypeId = model.TypeId,
                Start = start,
                End = end
            };

            await data.Events.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await data.Events
                .FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUser())
            {
                return Unauthorized();
            }

            var model = new EventFormModel()
            {
                Description = e.Description,
                Name = e.Name,
                End = e.End.ToString(DataConstants.DateFormat),
                Start = e.Start.ToString(DataConstants.DateFormat),
                TypeId = e.TypeId
            };

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormModel model, int id)
        {
            var e = await data.Events
                .FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUser())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState
                    .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState
                    .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            e.Start = start;
            e.End = end;
            e.Description = model.Description;
            e.Name = model.Name;
            e.TypeId = model.TypeId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var e = await data.Events
               .FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUser())
            {
                return Unauthorized();
            }

            var model = new EventFormModel()
            {
                Description = e.Description,
                Name = e.Name,
                End = e.End.ToString(DataConstants.DateFormat),
                Start = e.Start.ToString(DataConstants.DateFormat),
                Organiser = e.Organiser.UserName,
                CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                TypeId = e.TypeId
            };

            model.Types = await GetTypes();

            return View(model);
        }


        private async Task<List<TypeViewModel>> GetTypes()
        {
            return await data.Types
               .Select(t => new TypeViewModel()
               {
                   Id = t.Id,
                   Name = t.Name,
               })
               .ToListAsync();
        }

        private string GetUser()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
