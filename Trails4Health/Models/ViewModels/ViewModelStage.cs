using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelStage
    {
        public string StageName { get; set; }
        public string StageStartLoc { get; set; }
        public string StageEndLoc { get; set; }
        public bool IsActivated { get; set; }
        public int DifficultyID { get; set; }
        public string Geolocalization { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }

    }
}
