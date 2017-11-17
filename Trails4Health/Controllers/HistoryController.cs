using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Health.Models;
using Trails4Health.Models.ViewModels;

namespace Trails4Health.Controllers
{
    public class HistoryController : Controller
    {

        private IHistoryRepository repository;
        public int PageSize = 6;
        public HistoryController(IHistoryRepository repository)
        {
            this.repository = repository;
        }


        public ViewResult List(int page = 1)
        {
            return View(
                new HistoryListViewModel
                {
                    History = repository.History
                        .OrderBy(p => p.RealizationDate)
                        .Skip(PageSize * (page - 1))
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.History.Count()
                    }
                }
            );
        }
    }
}