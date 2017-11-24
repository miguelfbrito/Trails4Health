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
    public class HistoricsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoricsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Historics
        public async Task<IActionResult> CheckHistoric()
        {
            var applicationDbContext = _context.Historics.Include(h => h.Tourist).Include(h => h.Trail);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> HistoricInformation(int? idTourist, int? idTrail)
        {
            if (idTourist == null || idTrail == null)
            {
                return NotFound();
            }

            var historic = await _context.Historics
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .SingleAsync(m => m.TouristID == idTourist && m.TrailID == idTrail);
            if (historic == null)
            {
                return NotFound();
            }

            return View(historic);
        }

        // GET: Stages/Edit/5
        public async Task<IActionResult> AddInformation(int? idTourist, int? idTrail)
        {
            if (idTourist == null || idTrail == null)
            {
                return NotFound();
            }

            var historic = await _context.Historics.SingleAsync(m => m.TouristID == idTourist && m.TrailID == idTrail);
            if (historic == null)
            {
                return NotFound();
            }
            return View(historic);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInformation(int? idTourist, int? idTrail, [Bind("TimeTaken,RealizationDate,Observations")] Historic historic)
        {
            if (idTourist != historic.TouristID || idTrail != historic.TrailID)
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
                    if (!HistoricExists(historic.TouristID) || !HistoricExists(historic.TrailID))
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
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID", historic.TouristID);
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "TrailID", historic.TrailID);
            return View(historic);
        }
        /*
        // GET: Historics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Historics
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .SingleOrDefaultAsync(m => m.TouristID == id);
            if (historic == null)
            {
                return NotFound();
            }

            return View(historic);
        }

        // GET: Historics/Create
        public IActionResult Create()
        {
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID");
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc");
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeTaken,Observations,RealizationDate,TrailID,TouristID")] Historic historic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID", historic.TouristID);
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc", historic.TrailID);
            return View(historic);
        }

        // GET: Historics/Edit/5



        // POST: Historics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeTaken,Observations,RealizationDate,TrailID,TouristID")] Historic historic)
        {
            if (id != historic.TouristID)
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
                    if (!HistoricExists(historic.TouristID))
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
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID", historic.TouristID);
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc", historic.TrailID);
            return View(historic);
        }

        // GET: Historics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Historics
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .SingleOrDefaultAsync(m => m.TouristID == id);
            if (historic == null)
            {
                return NotFound();
            }

            return View(historic);
        }*/

        // POST: Historics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historic = await _context.Historics.SingleOrDefaultAsync(m => m.TouristID == id);
            _context.Historics.Remove(historic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HistoricExists(int id)
        {
            return _context.Historics.Any(e => e.TouristID == id);
        }
    }
}
