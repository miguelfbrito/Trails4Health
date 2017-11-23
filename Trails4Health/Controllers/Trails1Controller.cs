using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;

namespace Trails4Health.Controllers
{
    public class Trails1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Trails1Controller(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Trails1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trails.Include(t => t.Difficulty).Include(t => t.Season).Include(t => t.Slope);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trails1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails
                .Include(t => t.Difficulty)
                .Include(t => t.Season)
                .Include(t => t.Slope)
                .SingleOrDefaultAsync(m => m.TrailID == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // GET: Trails1/Create
        public IActionResult Create()
        {
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyLevel");
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonName");
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "SlopeType");
            return View();
        }

        // POST: Trails1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrailID,Name,Duration,DistanceToTravel,StartLoc,EndLoc,IsActivated,DifficultyID,SeasonID,SlopeID")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyID", trail.DifficultyID);
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonID", trail.SeasonID);
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "SlopeID", trail.SlopeID);
            return View(trail);
        }

        // GET: Trails1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails.SingleOrDefaultAsync(m => m.TrailID == id);
            if (trail == null)
            {
                return NotFound();
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyLevel", trail.DifficultyID);
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonName", trail.SeasonID);
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "SlopeType", trail.SlopeID);
            return View(trail);
        }

        // POST: Trails1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrailID,Name,Duration,DistanceToTravel,StartLoc,EndLoc,IsActivated,DifficultyID,SeasonID,SlopeID")] Trail trail)
        {
            if (id != trail.TrailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailExists(trail.TrailID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyID", trail.DifficultyID);
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonID", trail.SeasonID);
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "SlopeID", trail.SlopeID);
            return View(trail);
        }

        // GET: Trails1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails
                .Include(t => t.Difficulty)
                .Include(t => t.Season)
                .Include(t => t.Slope)
                .SingleOrDefaultAsync(m => m.TrailID == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // POST: Trails1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trail = await _context.Trails.SingleOrDefaultAsync(m => m.TrailID == id);
            _context.Trails.Remove(trail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrailExists(int id)
        {
            return _context.Trails.Any(e => e.TrailID == id);
        }
    }
}
