using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Trails4Health.Models;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models.ViewModels;

namespace Trails4Health.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trails.Include(t => t.Season).Include(t => t.Slope).Include(t => t.StatusTrails);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Home/TrailInfo/5
        public async Task<IActionResult> TrailInfo(int? id)
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Stage()
        {
            return View();
        }
        public IActionResult Login()
        {


            return View();
        }

        public IActionResult Register()
        {
         
            return View();
        }

        public IActionResult TrailsManagement()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

      

        
    }
}
