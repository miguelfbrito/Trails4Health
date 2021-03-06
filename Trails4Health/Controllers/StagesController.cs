using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
using Microsoft.AspNetCore.Authorization;
using Trails4Health.Models.ViewModels;

namespace Trails4Health.Controllers
{
    [Authorize (Roles = "Professor")]
    [RequireHttps]
    public class StagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Stages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Stages.Include(s =>s.Difficulty);
            return View(await applicationDbContext.ToListAsync());
        }

        //GET lista
        public async Task<IActionResult> Lista()
        {
            return View(await _context.Stages.ToListAsync());
        }

        // GET: Stages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stages
                .Include(s => s.Difficulty)
                .SingleOrDefaultAsync(m => m.StageId == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }

        // GET: Stages/Create
        public IActionResult Create()
        {
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "Level");
            return View();
        }

        // POST: Stages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StageId,StageName,StageStartLoc,StageEndLoc,IsActivated,Geolocalization,Distance,Duration,DifficultyID")] ViewModelStage VMStage)
        {
            if (ModelState.IsValid)
            {
                Stage stage = new Stage
                {
                    StageName = VMStage.StageName,
                    StageStartLoc = VMStage.StageStartLoc,
                    StageEndLoc = VMStage.StageEndLoc,
                    IsActivated = VMStage.IsActivated,
                    Geolocalization = VMStage.Geolocalization,
                    Distance = VMStage.Distance,
                    Duration = VMStage.Duration,
                    DifficultyID = VMStage.DifficultyID

                };
                _context.Add(stage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "Level",VMStage.DifficultyID);

            return View(VMStage);
        }

        // GET: Stages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stages.SingleOrDefaultAsync(m => m.StageId == id);
            if (stage == null)
            {
                return NotFound();
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "Level");

            return View(stage);
        }

        // POST: Stages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StageId,StageName,StageStartLoc,StageEndLoc,DifficultyID,IsActivated,Geolocalization,Distance,Duration")] Stage stage)
        {
            if (id != stage.StageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageExists(stage.StageId))
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
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "Level");

            return View(stage);
        }

        // GET: Stages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stages
                .Include(s => s.Difficulty)
                .SingleOrDefaultAsync(m => m.StageId == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }

        // POST: Stages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stage = await _context.Stages.SingleOrDefaultAsync(m => m.StageId == id);
            if (stage.IsActivated == true)
            {
                stage.IsActivated = false;
            }
            else
            {
                stage.IsActivated = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StageExists(int id)
        {
            return _context.Stages.Any(e => e.StageId == id);
        }
    }
}
