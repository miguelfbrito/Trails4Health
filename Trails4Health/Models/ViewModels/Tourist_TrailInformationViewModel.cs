using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class Tourist_TrailInformationViewModel
    {
        public Tourist_Trail Tourist_Trail { get; set; }
        public IEnumerable<Stage_Trail> Stages_Trail { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
