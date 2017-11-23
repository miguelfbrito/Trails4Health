﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Stage
    {
 

        public int StageId { get; set; }
        public string StageName { get; set; }
        public string StageStartLoc { get; set; }
        public string StageEndLoc { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }

        public ICollection<Stage_Trail> Stage_Trails { get; set; }

    }
}
