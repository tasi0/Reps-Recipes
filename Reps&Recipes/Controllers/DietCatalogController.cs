using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reps_Recipes.Data;
using Reps_Recipes.Models;

namespace Reps_Recipes.Controllers
{
    [Authorize]
    public class DietCatalogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DietCatalogController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

            ViewBag.DietId = id;
            ViewBag.Catalogs = new SelectList(catalogs, "Id", "Name");

            return View();
        }

        // POST: DietCatalog/AddToCatalog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCatalog(int dietId, int catalogId)
        {
            var entry = new CatalogDiets
            {
                DietId = dietId,
                CatalogId = catalogId
            };

            _context.CatalogDiets.Add(entry);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Diets", new { id = dietId });
        }

        public async Task<IActionResult> RemoveFromCatalog(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            var catalogs = await _context.Catalogs
                .Where(c => c.UserId == userId)
                .ToListAsync();

            ViewBag.DietId = id;
            ViewBag.Catalogs = new SelectList(catalogs, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDiet(int catalogId, int dietId)
        {
            var entry = await _context.CatalogDiets
                .FirstOrDefaultAsync(cd => cd.CatalogId == catalogId && cd.DietId == dietId);

            if (entry != null)
            {
                _context.CatalogDiets.Remove(entry);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Diets", new {id = dietId});
        }
    }
}
