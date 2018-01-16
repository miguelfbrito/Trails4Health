using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class HistoricListViewModel
    {
        public IEnumerable<Historic> Historics { get; set; }
        public IEnumerable<Tourist> Tourist { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Historic Historic { get; set; }
    }
}
