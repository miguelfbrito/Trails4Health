using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {
        public int TrailID { get; set; }

        [Required(ErrorMessage = "Please enter the Trail Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the Duration")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Please enter the Distance")]
        public int DistanceToTravel { get; set; }
        [Required(ErrorMessage = "Please enter the Start Location")]
        public string StartLoc { get; set; }
        [Required(ErrorMessage = "Please enter the End Location")]
        public string EndLoc { get; set; }
        public bool IsActivated { get; set; }
        
            //Tabela Dificuldade
        public Difficulty Difficulty { get; set; }
        public int DifficultyID { get; set; }

        //Tabela Season
        public Season Season{ get; set; }
        public int SeasonID { get; set; }

        //Tabela Desnível
        public Slope Slope { get; set; }
        public int SlopeID { get; set; }

        //Tabela Status_Trail
        public ICollection<Status_Trail> StatusTrails { get; set; }
        
        //Tabela Stage_Trail
        public ICollection<Stage_Trail> StagesTrails { get; set; }

    }
}
