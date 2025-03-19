using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reps_Recipes.Data;
using Reps_Recipes.Models;

namespace Reps_Recipes.Controllers
{
    public class WorkoutRegimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutRegimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutRegimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutRegimes.ToListAsync());
        }

        // GET: WorkoutRegimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRegime = await _context.WorkoutRegimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutRegime == null)
            {
                return NotFound();
            }

            return View(workoutRegime);
        }

        // GET: WorkoutRegimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutRegimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Difficulty,DurationMinutes")] WorkoutRegime workoutRegime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutRegime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutRegime);
        }

        // GET: WorkoutRegimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRegime = await _context.WorkoutRegimes.FindAsync(id);
            if (workoutRegime == null)
            {
                return NotFound();
            }
            return View(workoutRegime);
        }

        // POST: WorkoutRegimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Difficulty,DurationMinutes")] WorkoutRegime workoutRegime)
        {
            if (id != workoutRegime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutRegime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutRegimeExists(workoutRegime.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workoutRegime);
        }

        // GET: WorkoutRegimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRegime = await _context.WorkoutRegimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutRegime == null)
            {
                return NotFound();
            }

            return View(workoutRegime);
        }

        // POST: WorkoutRegimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutRegime = await _context.WorkoutRegimes.FindAsync(id);
            if (workoutRegime != null)
            {
                _context.WorkoutRegimes.Remove(workoutRegime);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutRegimeExists(int id)
        {
            return _context.WorkoutRegimes.Any(e => e.Id == id);
        }
    }
}
