using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Stage
    {
 

        public int idStage { get; set; }
        public String StageName { get; set; }
        public String StageStartLoc { get; set; }
        public String StageEndLoc { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }

    }
}
