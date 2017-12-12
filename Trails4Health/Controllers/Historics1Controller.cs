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
    public class Historics1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Historics1Controller(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Historics1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Historics.Include(h => h.Difficulty).Include(h => h.Tourist).Include(h => h.Trail);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Historics1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Historics
                .Include(h => h.Difficulty)
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .SingleOrDefaultAsync(m => m.HistoricID == id);
            if (historic == null)
            {
                return NotFound();
            }

            return View(historic);
        }

        // GET: Historics1/Create
        public IActionResult Create()
        {
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyID");
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID");
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc");
            return View();
        }

        // POST: Historics1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricID,TimeTaken,Observations,RealizationDate,DifficultyID,TrailID,TouristID")] Historic historic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyID", historic.DifficultyID);
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID", historic.TouristID);
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc", historic.TrailID);
            return View(historic);
        }

        // GET: Historics1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Historics.SingleOrDefaultAsync(m => m.HistoricID == id);
            if (historic == null)
            {
                return NotFound();
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyID", historic.DifficultyID);
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID", historic.TouristID);
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc", historic.TrailID);
            return View(historic);
        }

        // POST: Historics1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricID,TimeTaken,Observations,RealizationDate,DifficultyID,TrailID,TouristID")] Historic historic)
        {
            if (id != historic.HistoricID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricExists(historic.HistoricID))
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
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "DifficultyID", historic.DifficultyID);
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID", historic.TouristID);
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc", historic.TrailID);
            return View(historic);
        }

        // GET: Historics1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Historics
                .Include(h => h.Difficulty)
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .SingleOrDefaultAsync(m => m.HistoricID == id);
            if (historic == null)
            {
                return NotFound();
            }

            return View(historic);
        }

        // POST: Historics1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historic = await _context.Historics.SingleOrDefaultAsync(m => m.HistoricID == id);
            _context.Historics.Remove(historic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HistoricExists(int id)
        {
            return _context.Historics.Any(e => e.HistoricID == id);
        }
    }
}
