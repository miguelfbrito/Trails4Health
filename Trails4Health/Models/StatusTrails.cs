using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class StatusTrails
    {
        public int StatusTrailID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }   

        public string Reason { get; set; }


        //FK Trilhos

        public Trail Trail { get; set; }
        public int TrailID { get; set; }
        

        //FK Status
        public Status Status { get; set; }
        public int StatusID { get; set; }
        
    }
}


