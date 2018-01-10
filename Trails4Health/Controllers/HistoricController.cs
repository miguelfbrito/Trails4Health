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

        private IHistoricRepository repository;

        public int PageSize = 6;
        public HistoricController(IHistoricRepository repository)
        {
            this.repository = repository;
        }


      /*  public ViewResult CheckHistoric(int page = 1)
        {
            return View(
                new HistoricListViewModel
                {
                    Historic = repository.Historics
                        .OrderBy(p => p.RealizationDate)
                        .Skip(PageSize * (page - 1))
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Historics.Count()
                    }
                }
            );
        }*/

        
        public ViewResult CheckHistoric()
        { 
            return View(new HistoricListViewModel { Historic = repository.Historics });
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