using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class HistoricInformationViewModel
    {
        public Historic Historic { get; set; }
        public IEnumerable<Stage_Trail> Stages_Trail { get; set; }
    }
}
