using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {
        public int TrailID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int DistanceToTravel { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public bool IsActivated { get; set; }

        public ICollection<Stage_Trail> Stage_Trails { get; set; }

    }
}
