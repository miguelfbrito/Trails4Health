using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelTrail
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int DistanceToTravel { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public int SeasonID { get; set; }
        public int SlopeID { get; set; }
        public int StatusID { get; set; }
        public bool IsActivated { get; set; }


    }
}
