using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelTrailInfo
    {
        public Trail trail { get; set; }
        public IEnumerable<Stage_Trail> stagestrails { get; set; }
        public IEnumerable<StatusTrails> statustrails { get; set; }
    }
}
