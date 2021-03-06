﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{

    public class Tourist_Trail
    {

        public int Tourist_TrailID { get; set; }

        [Range(30, 500, ErrorMessage = "Tempo limitado entre 30 e 500 minutos.")]
        public int? Duration { get; set; }

        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Tamanho limitado entre 10 e 2000 caracteres.")]
        public string Observations { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [CheckDateRange(FirstDate = "01/01/2017", EndDate = "NOW")]
        public DateTime? RealizationDate { get; set; }

  
        public Difficulty Difficulty  { get; set; }
        public int? DifficultyID { get; set; }


        public Trail Trail { get; set; }
        public int TrailID { get; set; }

        public Tourist Tourist { get; set; }
        public int TouristID { get; set; }



    }

}


