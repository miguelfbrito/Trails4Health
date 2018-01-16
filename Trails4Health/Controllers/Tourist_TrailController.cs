using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
using Trails4Health.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Trails4Health.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Turista, Professor")]
    public class Tourist_TrailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tourist_TrailController(ApplicationDbContext context)
        {
            _context = context;
        }
        public int pageSize = 4;
        // GET: Tourist_Trails
        public IActionResult CheckHistoric(int page = 1)
        {
            string currentUrl = HttpContext.Request.QueryString.ToString();

            //    HistoricListViewModel historicListViewModel = new HistoricListViewModel();
            //   historicListViewModel.Tourist_Trails = _context.Tourist_Trails.Include(h => h.Tourist).Include(h => h.Trail).Where(h => h.Tourist.Email == User.Identity.Name).OrderByDescending(h => h.RealizationDate);
            return View(

                new Tourist_TrailListViewModel
                {
                    Tourist_Trails = _context.Tourist_Trails.Include(h => h.Tourist).Include(h => h.Trail).OrderByDescending(h => h.RealizationDate).Where(h => h.Tourist.Email == User.Identity.Name).Skip(pageSize * (page - 1))
                    .Take(pageSize),

                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = _context.Tourist_Trails.Count()
                    },

                    currentUrl = currentUrl
                }
                
                
                );
        }

        public async Task<IActionResult> HistoricInformation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tourist_TrailInformationViewModel hivm = new Tourist_TrailInformationViewModel();

            var tourist_trail = await _context.Tourist_Trails
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .Include(h => h.Difficulty)
            // TODO: rever    .Include(h => h.Trail.Difficulty)
                .Include(h => h.Trail.StagesTrails)
                .SingleAsync(m => m.Tourist_TrailID == id);

            hivm.Tourist_Trail = tourist_trail;

            int historicTrailID = tourist_trail.TrailID;

            var stages_trail = await _context.Stages_Trails
            .Include(h => h.Stage)
            .Where(m => m.TrailID == tourist_trail.TrailID)
            .OrderByDescending(h => h.StageOrder)
            .ToListAsync();



            hivm.Stages_Trail = stages_trail;

            if (tourist_trail == null)
            {
                return NotFound();
            }

            return View(hivm);
        }

        // GET: Stages/Edit/5
        public async Task<IActionResult> AddInformation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Tourist_Trails.SingleOrDefaultAsync(m => m.Tourist_TrailID == id);


            if (historic == null)
            {
                return NotFound();
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "Level", historic.DifficultyID);
            return View(historic);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInformation(int id, [Bind("Tourist_TrailID,TimeTaken,Observations,RealizationDate,DifficultyID,TrailID,TouristID")] Tourist_Trail historic)
        {
            if (id != historic.Tourist_TrailID)
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
                    if (!HistoricExist(historic.Tourist_TrailID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CheckHistoric");
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "Level", historic.DifficultyID);
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID", historic.TouristID);
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc", historic.TrailID);
            return View(historic);
        }


        // GET: Tourist_Trails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Tourist_Trails
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .SingleOrDefaultAsync(m => m.TouristID == id);
            if (historic == null)
            {
                return NotFound();
            }
            ViewData["DifficultyID"] = new SelectList(_context.Difficulties, "DifficultyID", "Level", historic.DifficultyID);
            return View(historic);
        }

        // GET: Tourist_Trails/Create
        public IActionResult Create()
        {
            ViewData["TouristID"] = new SelectList(_context.Tourists, "TouristID", "TouristID");
            ViewData["TrailID"] = new SelectList(_context.Trails, "TrailID", "EndLoc");
            return View();
        }

        private bool HistoricExist(int id)
        {
            return _context.Tourist_Trails.Any(e => e.Tourist_TrailID == id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tourist_TrailID,TimeTaken,Observations,RealizationDate,DifficultyID,TrailID,TouristID")] Tourist_Trail historic)
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

        // GET: Tourist_Trails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Tourist_Trails.SingleOrDefaultAsync(m => m.Tourist_TrailID == id);
            if (historic == null)
            {
                return NotFound();
            }
            return View(historic);
        }



        // POST: Tourist_Trails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tourist_TrailID,TimeTaken,Observations,RealizationDate")] Tourist_Trail historic)
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
                    if (!HistoricExist(historic.TouristID))
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

        // GET: Tourist_Trails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historic = await _context.Tourist_Trails
                .Include(h => h.Tourist)
                .Include(h => h.Trail)
                .SingleOrDefaultAsync(m => m.TouristID == id);
            if (historic == null)
            {
                return NotFound();
            }

            return View(historic);
        }

        // POST: Tourist_Trails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historic = await _context.Tourist_Trails.SingleOrDefaultAsync(m => m.TouristID == id);
            _context.Tourist_Trails.Remove(historic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
