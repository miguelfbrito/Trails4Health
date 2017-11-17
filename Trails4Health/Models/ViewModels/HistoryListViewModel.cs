using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class HistoryListViewModel
    {
        public IEnumerable<History> history { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
