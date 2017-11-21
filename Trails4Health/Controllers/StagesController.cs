using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Health.Models.ViewModels;
using Trails4Health.Models;

namespace Trails4Health.Controllers
{
    public class StagesController : Controller
    {

        private IStageRepository repository;

        public StagesController(IStageRepository repository)
        {
            this.repository = repository;
        }


        public ViewResult List()
        {
            return View(new StagesListViewModel
            {
                Stages = repository.Stages
                    .OrderBy(i => i.StageID)               
                
            });
        }
    }
}