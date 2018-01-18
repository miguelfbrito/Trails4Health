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

        [StringLength(2000, MinimumLength = 0, ErrorMessage = "Causa Inválida - Não deve exceder os 2000 caracteres.")]
        public string Reason { get; set; }


        //FK Trilhos

        public Trail Trail { get; set; }
        public int TrailID { get; set; }
        

        //FK Status
        public Status Status { get; set; }
        public int StatusID { get; set; }
        
    }
}


