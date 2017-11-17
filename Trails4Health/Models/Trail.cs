using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {
        public int ID_Trail { get; set; }
        public string Name { get; set; }
        public int AverageDuration { get; set; }
        public int DistanceToTravel { get; set; }
        public string Start_Loc { get; set; }
        public string End_Loc { get; set; }
        public string RecommendedTime { get; set; }
        public bool Is_Activated { get; set; }
        public int ID_Difficulty {get;set;}
    }
}
