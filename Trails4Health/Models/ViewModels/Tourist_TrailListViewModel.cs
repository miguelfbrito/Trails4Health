using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class Tourist_TrailListViewModel
    {
        public IEnumerable<Tourist_Trail> Tourist_Trails { get; set; }
        public IEnumerable<Tourist> Tourist { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Tourist_Trail Tourist_Trail { get; set; }
        public string currentUrl { get; set; }
    }
}
