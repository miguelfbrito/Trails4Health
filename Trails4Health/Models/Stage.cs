using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Trails4Health.Models
{
    public class Stage
    {

        
        public int StageId { get; set; }

        [Required(ErrorMessage = "Please enter the Stage Name")]
        public string StageName { get; set; }

        [Required(ErrorMessage = "Please enter the Stage Starting Location")]
        public string StageStartLoc { get; set; }

        [Required(ErrorMessage = "Please enter the Stage Ending Location")]
        public string StageEndLoc { get; set; }

        [Required(ErrorMessage = "Please enter if the Stage is active")]
        public bool IsActivated { get; set; }

        [Required(ErrorMessage = "Please enter the Geolocalization")]
        public string Geolocalization { get; set; }

        [Required(ErrorMessage = "Please enter the Distance")]
        public int Distance { get; set; }

        [Required(ErrorMessage = "Please enter the Duration")]
        public int Duration { get; set; }

        public ICollection<Stage_Trail> StagesTrails { get; set; }
    }
}
