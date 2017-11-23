using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {
        public int TrailID { get; set; }
        public int TrailStagesID { get; set; }
        public int DifficultyID { get; set; }
        public int VariabilityID { get; set; }
        public int Duration { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public int SeasonID { get; set; }
        public bool IsActivated { get; set; }
        public String Name { get; set; }
        public String AdvisedPeriod { get; set; }


    }
}
