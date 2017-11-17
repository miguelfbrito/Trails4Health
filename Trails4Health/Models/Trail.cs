using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {
        public int IdTrail { get; set; }
        public int IdTrailStages { get; set; }
        public int IdDifficulty { get; set; }
        public int IdVariability { get; set; }
        public String Name { get; set; }
        public String AdvisedPeriod { get; set; }


    }
}
