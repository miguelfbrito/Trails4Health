using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{

    public class Historic
    {
        [Required(ErrorMessage = "Please enter the duration.")]
        public int TimeTaken { get; set; }

        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Invalid")]
        [Required(ErrorMessage = "Please enter the observation.")]
        public String Observations { get; set; }

        [Required(ErrorMessage = "Please enter the date.")]
        public string RealizationDate { get; set; }
        
        public Difficulty Difficulty  { get; set; }
        public int? DifficultyID { get; set; }

        public Trail Trail { get; set; }
        public int TrailID { get; set; }

        public Tourist Tourist { get; set; }
        public int TouristID { get; set; }

    }
}
