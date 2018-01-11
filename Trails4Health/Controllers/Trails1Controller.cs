using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
using Trails4Health.Models.ViewModels;

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
            var applicationDbContext = _context.Trails.Include(t => t.Season).Include(t => t.Slope).Include(t => t.StatusTrails);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trails1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewModelTrailsDetails vmtd = new ViewModelTrailsDetails();

            var trail = await _context.Trails
                .Include(t => t.Season)
                .Include(t => t.Slope)
                .SingleOrDefaultAsync(m => m.TrailID == id);

            vmtd.trail = trail;
            var statustrails = await _context.StatusTrails.
                Include(t => t.Status).
               Where(m => m.TrailID == trail.TrailID).
               ToListAsync();
            vmtd.statustrails = statustrails;

            if (trail == null)
            {
                return NotFound();
            }
            return View(vmtd);
        }




        // GET: Trails1/Create
        public IActionResult Create()
        {
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonName");
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "Type");
            ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusName");
            return View();
        }


        // POST: Trails1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrailID,Name,Duration,DistanceToTravel,StartLoc,EndLoc,IsActivated,SeasonID,SlopeID,IsActivated,StatusID")] ViewModelTrail VMTrail)
        {
            if (ModelState.IsValid)
            {
                Trail trail = new Trail
                {
                    Name = VMTrail.Name,
                    Duration = VMTrail.Duration,
                    DistanceToTravel = VMTrail.DistanceToTravel,
                    StartLoc = VMTrail.StartLoc,
                    EndLoc = VMTrail.EndLoc,
                    SeasonID = VMTrail.SeasonID,
                    SlopeID = VMTrail.SlopeID,
                    IsActivated = VMTrail.IsActivated
                };
                _context.Add(trail);

                StatusTrails statusTrail = new StatusTrails
                {
                    Trail = trail,
                    StatusID = VMTrail.StatusID,
                    StartDate = DateTime.Now

                };

                _context.Add(statusTrail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonName", VMTrail.SeasonID);
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "Type", VMTrail.SlopeID);
            return View(VMTrail);
        }

        //GET: Trails1/EditTrailStatus
        public async Task<ActionResult>EditTrailStatus(int? id)
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

            ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusName");

            return View();
        }

        //POST: Trails1/EditTrailStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrailStatus(int id, [Bind("StatusID","StartDate","EndDate")] StatusTrails statustrails)
        {
            if (ModelState.IsValid)
            {
                StatusTrails StatusTrail = new StatusTrails
                {
                    StatusID = statustrails.StatusID,
                    TrailID = id,
                    StartDate = statustrails.StartDate,
                    EndDate = statustrails.EndDate,
                    Reason = statustrails.Reason
                };
                _context.Add(StatusTrail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusName");
            return View();
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
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonName", trail.SeasonID);
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "Type", trail.SlopeID);
            return View(trail);
        }

        // POST: Trails1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrailID,Name,Duration,DistanceToTravel,StartLoc,EndLoc,IsActivated,SeasonID,SlopeID")] Trail trail)
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
            ViewData["SeasonID"] = new SelectList(_context.Seasons, "SeasonID", "SeasonName", trail.SeasonID);
            ViewData["SlopeID"] = new SelectList(_context.Slopes, "SlopeID", "Type", trail.SlopeID);
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
            if (trail.IsActivated == true)
            {
                trail.IsActivated = false;
            }
            else
            {
                trail.IsActivated = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrailExists(int id)
        {
            return _context.Trails.Any(e => e.TrailID == id);
        }
    }
}
