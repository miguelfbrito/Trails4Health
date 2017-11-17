using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Trails4Health.Controllers
{
    public class StagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}