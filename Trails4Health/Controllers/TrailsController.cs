using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;
using Trails4Health.Models.ViewModels;

namespace Trails4Health.Controllers
{
    public class TrailsController : Controller
    {
        private ITrailsRepository repository;

        public TrailsController(ITrailsRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult TrailsManagement()
        {
            return View(
                new TrailsListViewModel
                {
                    Trails = repository.Trails
                }
                
                
                );
        }

    }
}
