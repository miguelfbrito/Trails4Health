using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class HistoricListViewModel
    {
        public IEnumerable<Historic> Historic { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
