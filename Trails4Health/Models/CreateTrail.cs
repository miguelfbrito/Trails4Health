using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Trails4Health.Models
{
    public class CreateTrail
    {
        [Required(ErrorMessage = "Please enter the Trail Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter where the Trail starts")]
        public string StartLoc { get; set; }

        [Required(ErrorMessage = "Please enter where the Trail ends")]
        public string EndLoc { get; set; }

        [Required(ErrorMessage = "Please select the best season to go through the trail")]
        public string Season { get; set; }

        [Required(ErrorMessage = "Please select the difficulty of the trail")]
        public string Difficulty { get; set; }
    }
}
