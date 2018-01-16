using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Health.Models;
using Trails4Health.Models.ViewModels;

namespace Trails4Health.Controllers
{

    public class HistoricController : Controller
    {

        private ITourist_TrailRepository repository;

        public int PageSize = 6;
        public HistoricController(ITourist_TrailRepository repository)
        {
            this.repository = repository;
        }


      /*  public ViewResult CheckHistoric(int page = 1)
        {
            return View(
                new HistoricListViewModel
                {
                    Historic = repository.Tourist_Trails
                        .OrderBy(p => p.RealizationDate)
                        .Skip(PageSize * (page - 1))
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Tourist_Trails.Count()
                    }
                }
            );
        }*/

        
        public ViewResult CheckHistoric()
        { 
            return View(new Tourist_TrailListViewModel { Tourist_Trails = repository.Historics });
        }

        public ViewResult AddInformation()
        {
            return View();
        }

        public ViewResult HistoricInformation()
        {
            return View();
        }

    }
}