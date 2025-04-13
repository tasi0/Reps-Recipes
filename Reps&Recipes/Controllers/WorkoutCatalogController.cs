using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reps_Recipes.Data;
using Reps_Recipes.Models;

namespace Reps_Recipes.Controllers
{
    public class WorkoutCatalogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WorkoutCatalogController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: DietCatalog/AddToCatalog/5
        public async Task<IActionResult> AddToCatalog(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            var catalogs = await _context.Catalogs
                .Where(c => c.UserId == userId)
                .ToListAsync();

            ViewBag.WorkoutRegimeId = id;
            ViewBag.Catalogs = new SelectList(catalogs, "Id", "Name");

            return View();
        }

        // POST: DietCatalog/AddToCatalog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCatalog(int regimeId, int catalogId)
        {
            var entry = new CatalogRegimes
            {
                WorkoutRegimeId = regimeId,
                CatalogId = catalogId
            };

            _context.CatalogRegimes.Add(entry);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "WorkoutRegimes", new {id = regimeId});
        }


        [HttpPost]
        public async Task<IActionResult> RemoveWorkoutFromCatalog(int catalogId, int regimeId)
        {
            var entry = await _context.CatalogRegimes
                .FirstOrDefaultAsync(cr => cr.CatalogId == catalogId && cr.WorkoutRegimeId == regimeId);

            if (entry != null)
            {
                _context.CatalogRegimes.Remove(entry);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "WorkoutRegimes", new { id = regimeId });
        }
    }
}
