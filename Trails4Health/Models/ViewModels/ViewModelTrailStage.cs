using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelTrailStage
    {
        public Trail trail { get; set; }
        public Stage stage { get; set; }
        public bool stageintrail { get; set; }

        //public string StageName { get; set; }
        //public string StageStartLoc { get; set; }
        //public string StageEndLoc { get; set; }
        //public bool IsActivated { get; set; }
        //public int DifficultyID { get; set; }
        //public string Geolocalization { get; set; }
        //public int Distance { get; set; }
        //public int Duration { get; set; }

        public Difficulty Difficulty { get; set; }
    }
}
